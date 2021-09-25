
![ASD](https://img.shields.io/badge/VS%202019-Visual%20Studio-blueviolet) ![ASD](https://img.shields.io/badge/ASP.NET%20CORE-.NET%205-blue)
## 

<img align="left" alt="Client-Server Application" src="https://i.ibb.co/8K7Vx3t/client-server-1.png">



## :one:  Client-Server İlişkisi

- **Client Side - İstemci tarafı** (veya sadece, müşteri)  uygulamanın nasıl göründüğünü ve son kullanıcı ile nasıl etkileşime girdiğini işleyen bir kullanıcı arayüzü ( **UI** ) sağlar. Kullanıcının makinesinde geçici ve yerel depolama vb. gibi kaynakları kullanabilir ve tüketebilir.
- **Server Side - Sunucu tarafı** (veya basitçe, sunucu) müşterilerinden gelen istekleri alan taraftır ve müşteriye uygun veri geri göndermek için mantığı içerir. Kullanıcı arayüzü yerine, sunucu genellikle bir uygulama programlama arayüzüne ( **API** ) sahiptir. Ayrıca, sunucu genellikle uygulama için tüm verileri kalıcı olarak depolayacak bir **veritabanı** içerir .

## 

<img align="left" width="400" src="https://i.ibb.co/DL8cX2f/1-JL9-U9r-EDVn-X7-NXy-STw1-HXA.png" alt="1-JL9-U9r-EDVn-X7-NXy-STw1-HXA" border="0">



## :two: WebSocket Nedir ?

Websocket HTTP'den farklı olarak TCP protokolünü kullanır. Client-Server arasında çift yönlü mesajlaşmayı sağlar. HTTP protokolüne uygun olmayan real time web uygulamalarımızdaki karmaşık yapının basitleştirilmesini sağlar.

- Bir istekte bulunulduğu zaman cevap beklenilmemektedir. Tabi isteğe ya da ihtiyaca göre cevapta dönülebilir.
- WebSocket protokolü, İnternet iletişiminin genel giderlerini azaltır ve Web sunucuları ve istemciler arasında verimli ve durumlu iletişim sağlar.
- Çok hızlı ve ucuz olmasının çok ötesinde sunucu ile istemci arasında herhangi bir ara yazılıma veya uygulamaya gerek duymaz.



<img align="left" width="500" src="https://i.ibb.co/4tLFhDZ/8db2df13-524e-4494-b65a-7caa972acced.png" alt="signalr" border="0">

## :three: SignalR Nedir ?

Altında yatan teknoloji websockettir. Websocket geliştirmenin zaman maliyeti olduğu için Microsoft tarafından geliştirilmiş açık kaynak kodlu bir kütüphanedir. **RPC** (Remote Procedure Call) mekanizmasını benimsemektedir. **RPC** sayesinde server client'ta bulunan herhangibir metodun tetiklenmesini ve veri transferini sağlayabilmektedir. Böylece uygulamalar serverdan sayfa yenilemeksizin data transferini sağlamış olarak ve gerçek zamanlı uygulama davranışı sergilemiş olacaktır. Uygulamanın gerçek zamanlı olması cilent ile server'ın anlık olarak karşılıklı haberleşmesi anlamına gelmektedir. Google tarafından geliştirilen grpc aynı mekanizmayı kullanan diğer bir örnektir.

Microsoft tarafından 2011 yılında geliştirilmiştir. 2013 yılında Asp.NET mimarisine entegre edilmiştir. .Net Core mimarilarinde de rahatlıkla kullanılabilmektedir. O yıllarda tüm browserların WebSocket protokolünü desteklemesi üzerinde SignalR'ın kendi altyapısıyla gelerek client ile server arasındaki haberleşmeyi real time olarak gerçekleştirebiliyor olması bir anda popüler hale getirmiştir.

## :four: SignalR Nasıl Çalışmaktadır ?

SingalR **Hub** ismi verilen merkezi bir yapı üzerinden şekillenmektedir. **Hub** özünde bir class'tır ve içerisinde tanımlanan bir metoda subscribe olan tüm client'lar ilgili **Hub** üzerinden iletilen mesajları alacaktırlar.

<img align="left" src="https://i.ibb.co/tCNCjQF/signalrflow.png" alt="signalrflow">



