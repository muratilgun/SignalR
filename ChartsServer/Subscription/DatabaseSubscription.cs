using ChartsServer.Hubs;
using ChartsServer.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace ChartsServer.Subscription
{
    public interface IDatabaseSubscription
    {
        void Configure(string tableName);
    }
    public class DatabaseSubscription<T> : IDatabaseSubscription where T : class, new()
    {
        IConfiguration _configuration;
        IHubContext<SatisHub> _hubContext;
        public DatabaseSubscription(IConfiguration configuration, IHubContext<SatisHub> hubContext)
        {
            _configuration = configuration;
            _hubContext = hubContext;
        }

        SqlTableDependency<T> _tableDependency;

        public void Configure(string tableName)
        {
            _tableDependency = new SqlTableDependency<T>(_configuration.GetConnectionString("SQL"), tableName);
            _tableDependency.OnChanged += async (o, e) =>
            {

                SatisDBContext dBContext = new SatisDBContext();
                var data = (from personel in dBContext.Personellers
                             join satis in dBContext.Satislars
                             on personel.Id equals satis.PersonelId
                             select new { personel, satis }).ToList();
                List<object> list = new List<object>();
                var personelIsimleri = data.Select(d => d.personel.Adi).Distinct().ToList();
                personelIsimleri.ForEach(p =>
                {
                    list.Add(new
                    {
                        name = p,
                        data = data.Where(s => s.personel.Adi == p).Select(s => s.satis.Fiyat).ToList()
                    }); 
                });
                await _hubContext.Clients.All.SendAsync("receiveMessage", list);
            };
            _tableDependency.OnError += (o, e) =>
            {

            };
            _tableDependency.Start();
        }

        ~DatabaseSubscription()
        {
            _tableDependency.Stop();
        }
    }
}
