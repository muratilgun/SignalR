import { Component } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import  * as Highcharts from 'highcharts';
 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  connection : signalR.HubConnection;
  constructor(){
    this.connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:5001/satishub")
    .build();
    this.connection.start();
    this.connection.on("receiveMessage", message => {
      console.log(message)
      for (let i= 0; i < this.chart.series.length; i++ ){
        this.chart.series[i].remove();
      }
      for (let i = 0; i< message.length; i++){
        this.chart.addSeries(message[i]);
      }
      this.updateFromInput = true;
      this.chart.hideLoading();


      this.chartOptions.series = message;
      this.updateFromInput = true;
      this.chart.hideLoading();

    });
    const self = this;
    this.chartCallback = chart => {
      self.chart = chart;
    }

  }
  chart;
  updateFromInput = false;
  chartCallback;
  Highcharts : typeof Highcharts = Highcharts;
  chartOptions: Highcharts.Options ={
    //Grafic title
    title:{
      text : "Başlık"
    },
    //Sub title
    subtitle : {
      text: "Alt Başlık"
    },
    //Y Ekseni
    yAxis: {
     title:{ text:
       "Y ekseni" }
    },
    // X Ekseni
    xAxis: {
     accessibility:{ 
      rangeDescription: "2019 - 2020" }
    },
    legend:{
      layout: "vertical",
      align: "right",
      verticalAlign: "middle"
    },
    plotOptions: {
      series: {
        label: {
          connectorAllowed: true
        },
        pointStart: 100
      }
    }
  }
}