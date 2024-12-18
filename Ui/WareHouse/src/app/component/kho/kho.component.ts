import { AfterViewInit, Component, OnInit } from '@angular/core';
import { KhoService } from 'src/app/service/kho.service';
import * as $ from 'jquery';
import 'datatables.net';

@Component({
  selector: 'app-kho',
  templateUrl: './kho.component.html',
  styleUrls: ['./kho.component.css']
})
export class KhoComponent implements OnInit{
  khoData: any;

  constructor(private khoService: KhoService) { }

  ngOnInit(): void {
    this.khoService.getKho().subscribe(
      response => {
        this.khoData = response;
        console.log(this.khoData);
        // Khởi tạo lại DataTable sau khi dữ liệu được tải
        setTimeout(() => {
          $('#khoTable').DataTable();
        }, 0);
      },
      error => {
        console.error('Error fetching kho data', error);
      }
    );
  }
}
