import { Component, OnInit, OnDestroy } from '@angular/core';
import { takeUntil } from 'rxjs/internal/operators/takeUntil';
import { PocService } from 'src/app/service/poc.service';
import { Subject } from 'rxjs';
import { monkeyPatchChartJsTooltip, monkeyPatchChartJsLegend } from 'ng2-charts';

@Component({
  selector: 'app-graph-pie',
  templateUrl: './graph-pie.component.html',
  styleUrls: ['./graph-pie.component.css']
})
export class GraphPieComponent implements OnInit, OnDestroy {

  constructor(private pocService: PocService) {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
  }
 
  public pieChartLabels = ['', '', '']
  public pieChartData = [, ,];
  public pieChartType = 'pie';

  pieChartOptions = {
    responsive: true,
    title: {
      text: 'Number of employees per department', 
      display: true
    },
    percent: true, 
  };
 
  private unsubscribe: Subject<void> = new Subject();

  ngOnInit() {
    this.pocService.getEmployeesPerDepartament().pipe(takeUntil(this.unsubscribe))
      .subscribe(result => {
        this.pieChartData = []; this.pieChartLabels = [];
        if (result != null) {
          result.forEach(e => {
            this.pieChartLabels.push(e.departament.name);
            this.pieChartData.push(e.count);
          });
        }
      });
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }


}
