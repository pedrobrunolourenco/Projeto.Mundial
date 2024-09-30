import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor() {}

  title = 'Mundial';

  ngOnInit() {
    window.addEventListener('beforeunload', () => {
      localStorage.removeItem("token-mundial");
    });
  }


}
