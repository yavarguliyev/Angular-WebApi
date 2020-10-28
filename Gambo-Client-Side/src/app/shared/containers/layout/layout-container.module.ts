import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { MenuComponent } from './menu/menu.component';
import { FooterComponent } from './footer/footer.component';
import { CopyrightComponent } from './copyright/copyright.component';

@NgModule({
  declarations: [HeaderComponent, MenuComponent, FooterComponent, CopyrightComponent],
  imports: [
    CommonModule
  ],
  exports: [
    HeaderComponent,
    MenuComponent,
    FooterComponent,
    CopyrightComponent
  ]
})
export class LayoutContainerModule { }
