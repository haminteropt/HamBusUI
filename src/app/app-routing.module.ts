import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { RigBusEditComponent } from './components/rig-bus-edit/rig-bus-edit.component';




const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'rigEdit', component: RigBusEditComponent },
  { path: 'home', component: HomeComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
