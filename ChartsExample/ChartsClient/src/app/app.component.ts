import { Component } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import  * as Highcharts from 'highcharts';
 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  Highcharts : typeof Highcharts = Highcharts;
  chartOption: Highcharts.Options ={
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
    series:[
      {
        name: "X",
        type: "line",
        data: [1000,2000,3000]
      },
      {
        name: "Y",
        type: "line",
        data: [500,7800,4600]
      },
      {
        name: "Z",
        type: "line",
        data: [850,1200,6700]
      }
    ],
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
