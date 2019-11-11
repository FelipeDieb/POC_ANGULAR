import { Component, OnInit, OnDestroy } from '@angular/core';
import { PocService } from 'src/app/service/poc.service';
import { takeUntil } from 'rxjs/internal/operators/takeUntil';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-graph-bar',
  templateUrl: './graph-bar.component.html',
  styleUrls: ['./graph-bar.component.css']
})
export class GraphBarComponent implements OnInit , OnDestroy{

  constructor(private pocService:PocService) { }

  public barChartOptions = {
    scaleShowVerticalLines: false,
    title: {
      text: 'Salaries per employee',
      display: true
    },
    responsive: true
  };
  public barChartLabels = [];
  public barChartType = 'bar';
  public barChartLegend = false;
  public barChartData = [{data: [], label: 'Employees'}];
  public data2 = [];
  private unsubscribe: Subject<void> = new Subject();

   ngOnInit() {
    this.pocService.getEmployees().pipe(takeUntil(this.unsubscribe))
    .subscribe(result => {  
      this.barChartData = []; 
      if(result!=null){
        result.forEach(e => {
          this.barChartLabels.push(e.name);
          this.data2.push(e.salary);
        }); 
        this.barChartData.push({data: this.data2 , label: 'Employees'});
      } 
    });
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

}
