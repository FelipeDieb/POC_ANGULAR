import { Component, OnInit } from '@angular/core';
import { Color, Label } from 'ng2-charts';
import { ChartDataSets } from 'chart.js';
import { PocService } from 'src/app/service/poc.service';
import { takeUntil } from 'rxjs/internal/operators/takeUntil';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-graph-line',
  templateUrl: './graph-line.component.html',
  styleUrls: ['./graph-line.component.css']
})
export class GraphLineComponent implements OnInit {

  constructor(private pocService:PocService) { }

  private unsubscribe: Subject<void> = new Subject();
  
  lineChartData: ChartDataSets[] = [{data: [], label: 'Employees'}];
 

  lineChartLabels: Label[] = ['January', 'February', 'March', 'April', 'May', 'June'];

  lineChartOptions = {
    responsive: true,
    title: {
      text: 'Employees started from January to June',
      display: true
    },
    render: 'percentage'
  };

  lineChartLegend = false;
  lineChartPlugins = [];
  lineChartType = 'line';

  public data2 = [];

  ngOnInit() {
    this.pocService.getEmployeesStartedJanAndjune().pipe(takeUntil(this.unsubscribe))
    .subscribe(result => {  
      this.lineChartData = []; 
      this.lineChartLabels = [];
      if(result!=null){
        
        result.forEach(e => {
          console.log(JSON.stringify(e))
          this.lineChartLabels.push(e.month.name);
          this.data2.push(e.count);
        }); 
        this.lineChartData.push({data: this.data2 , label: 'Employees'});
      } 
    });
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }


 
  
}
