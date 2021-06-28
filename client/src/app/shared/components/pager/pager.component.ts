import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss'],
})
export class PagerComponent implements OnInit {
  constructor() {}

  @Input() totalItems: number;
  @Input() pageSize: number;
  @Output() pageChanged = new EventEmitter<number>();

  ngOnInit(): void {}

  pagerChanged(event: PageChangedEvent) {
    this.pageChanged.emit(event.page);
  }
}
