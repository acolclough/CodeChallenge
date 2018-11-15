import { Component } from '@angular/core';
import { DataService } from './data-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'CodeChallenge';
  public data;
  public chart;
  dataLoaded: Promise<boolean>;
  constructor(private _dataService: DataService) { }
  
  ngOnInit() {
    this.getChartData(); 
  }
  
  getChartData() {
   return this._dataService.getChartData().subscribe(
      data => { this.data = data }, err => console.error(err), () => {
        console.log(this.data)
        this.chart = {
          labels: this.data.years,
          datasets: [
           {
            label: 'Years',
             backgroundColor: '#42A5F5',
                    borderColor: '#1E88E5',
                    data:  this.data.dataSet
           }
          ]
        }
        this.dataLoaded = Promise.resolve(true);
      });
  }
}
