import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { SassLandingOneComponent } from "./components/pages/sass-landing-one/sass-landing-one.component";
import { AppLandingComponent } from "./components/pages/app-landing/app-landing.component";
import { SassLandingTwoComponent } from "./components/pages/sass-landing-two/sass-landing-two.component";
import { AgencyLandingOneComponent } from "./components/pages/agency-landing-one/agency-landing-one.component";
import { AgencyLandingTwoComponent } from "./components/pages/agency-landing-two/agency-landing-two.component";
import { PortfolioLandingComponent } from "./components/pages/portfolio-landing/portfolio-landing.component";
import { InicioComponent } from "./components/pages/inicio/inicio.component";
import { IngresarComponent } from "./components/pages/ingresar/ingresar.component";
import { DashboardAdminComponent } from "./components/pages/dashboard-admin/dashboard-admin.component";
import { DashboardClienteComponent } from "./components/pages/dashboard-cliente/dashboard-cliente.component";
import { DashboardEmprendimientoComponent } from "./components/pages/dashboard-emprendimiento/dashboard-emprendimiento.component";
import { AgregarAdministradorComponent } from "./components/pages/dashboard-admin/agregar-administrador/agregar-administrador.component";
import { AgregarPreguntaComponent } from "./components/pages/dashboard-admin/agregar-pregunta/agregar-pregunta.component";
import { AgregarEmprendimientoComponent } from "./components/pages/dashboard-cliente/agregar-emprendimiento/agregar-emprendimiento.component";
import { NuevoRegistroComponent } from "./components/pages/ingresar/nuevo-registro/nuevo-registro.component";
import { DashboardRepartidorComponent } from "./components/pages/dashboard-repartidor/dashboard-repartidor.component";
import { AgregarTallerComponent } from "./components/pages/dashboard-emprendimiento/agregar-taller/agregar-taller.component";
import { clienteGuard } from "./cliente.guard";
import { emprendimientoGuard } from "./emprendimiento.guard";
import { repartidorGuard } from "./repartidor.guard";
import { adminGuard } from "./admin.guard";
import { GestionSolicitudesComponent } from "./components/pages/dashboard-admin/gestion-solicitudes/gestion-solicitudes.component";
import { GestionPreguntasComponent } from "./components/pages/dashboard-admin/gestion-preguntas/gestion-preguntas.component";
import { GestionAdministradoresComponent } from "./components/pages/dashboard-admin/gestion-administradores/gestion-administradores.component";
import { GestionTalleresComponent } from "./components/pages/dashboard-emprendimiento/gestion-talleres/gestion-talleres.component";
import { GestionEmprendimientoAdminsComponent } from "./components/pages/dashboard-emprendimiento/gestion-emprendimiento-admins/gestion-emprendimiento-admins.component";
import { VerOrdenesComponent } from "./components/pages/dashboard-repartidor/ver-ordenes/ver-ordenes.component";
import { VerTalleresComponent } from "./components/pages/dashboard-cliente/ver-talleres/ver-talleres.component";
import { GestionEmprendimientosComponent } from "./components/pages/dashboard-cliente/gestion-emprendimientos/gestion-emprendimientos.component";
import { MisPedidosComponent } from "./components/pages/dashboard-cliente/mis-pedidos/mis-pedidos.component";
import { Login2Component } from "./components/pages/ingresar/login2/login2.component";
import { CompletarInfoComponent } from "./components/pages/ingresar/completar-info/completar-info.component";
import { GestionPagosComponent } from "./components/pages/dashboard-emprendimiento/gestion-pagos/gestion-pagos.component";
import { EntradasComponent } from "./components/pages/dashboard-cliente/entradas/entradas.component";
import { combinedGuard } from "./services/combined.guard";
import { GestionInventarioComponent } from "./components/pages/dashboard-admin/gestion-inventario/gestion-inventario.component";
import { ForumComponent } from "./forum/forum.component";
import { CreatePostComponent } from "./create-post/create-post.component";
import { PostComponent } from "./post/post.component";
import { OrdenesComponent } from "./ordenes/ordenes.component";
import { CrearOrdenComponent } from "./crear-orden/crear-orden.component";
import { VerOrdenesEmprendedorComponent } from "./ver-ordenes-emprendedor/ver-ordenes-emprendedor.component";

const routes: Routes = [
    { path: "", component: InicioComponent },
    { path: "sass-landing-one", component: SassLandingOneComponent },
    { path: "sass-landing-two", component: SassLandingTwoComponent },
    { path: "app-landing", component: AppLandingComponent },
    { path: "agency-landing-one", component: AgencyLandingOneComponent },
    { path: "agency-landing-two", component: AgencyLandingTwoComponent },
    { path: "portfolio-landing", component: PortfolioLandingComponent },

    { path: "inicio", component: InicioComponent },
    { path: "ingresar", component: IngresarComponent },
    {
        path: "dashboard-admin",
        component: DashboardAdminComponent,
        canActivate: [adminGuard],
    },
    {
        path: "dashboard-cliente",
        component: DashboardClienteComponent,
        canActivate: [clienteGuard],
    },
    {
        path: "dashboard-emprendimiento",
        component: DashboardEmprendimientoComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "dashboard-repartidor",
        component: DashboardRepartidorComponent,
        canActivate: [repartidorGuard],
    },
    {
        path: "agregar-administrador",
        component: AgregarAdministradorComponent,
        canActivate: [adminGuard],
    },
    {
        path: "editar-perfil",
        component: AgregarAdministradorComponent,
        canActivate: [combinedGuard],
    },
    {
        path: "editar-administrador",
        component: AgregarAdministradorComponent,
        canActivate: [adminGuard],
    },

    {
        path: "actualizar-pregunta/:id",
        component: AgregarPreguntaComponent,
        canActivate: [adminGuard],
    },
    {
        path: "nueva-pregunta",
        component: AgregarPreguntaComponent,
        canActivate: [adminGuard],
    },
    {
        path: "nuevo-emprendimiento",
        component: AgregarEmprendimientoComponent,
        canActivate: [clienteGuard],
    },
    {
        path: "editar-emprendimiento/:id",
        component: AgregarEmprendimientoComponent,
        canActivate: [emprendimientoGuard],
    },
    { path: "registrarse", component: NuevoRegistroComponent },
    { path: "registrarse/google", component: CompletarInfoComponent },
    {
        path: "nuevo-taller",
        component: AgregarTallerComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "nuevo-taller/:entrepeneurshipId",
        component: AgregarTallerComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "actualizar-taller/:entrepeneurshipId/:id",
        component: AgregarTallerComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "talleres/:entrepeneurshipId",
        component: GestionTalleresComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "pagos/:entrepeneurshipId",
        component: GestionPagosComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "entradas",
        component: EntradasComponent,
        canActivate: [clienteGuard],
    },
    {
        path: "actualizar-taller/:id",
        component: AgregarTallerComponent,
        canActivate: [emprendimientoGuard],
    },

    {
        path: "mi-perfil/emprendimiento",
        component: AgregarEmprendimientoComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "pagos",
        component: GestionPagosComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "solicitudes",
        component: GestionSolicitudesComponent,
        canActivate: [adminGuard],
    },
    {
        path: "preguntas",
        component: GestionPreguntasComponent,
        canActivate: [adminGuard],
    },
    {
        path: "administradores",
        component: GestionAdministradoresComponent,
        canActivate: [adminGuard],
    },
    {
        path: "talleres",
        component: GestionTalleresComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "emprendimiento-admins/:id",
        component: GestionEmprendimientoAdminsComponent,
        canActivate: [emprendimientoGuard],
    },

    {
        path: "pedidos",
        component: VerOrdenesComponent,
        canActivate: [repartidorGuard],
    },
    {
        path: "ver-talleres",
        component: VerTalleresComponent,
        canActivate: [clienteGuard],
    },
    {
        path: "editar-inventario",
        component: GestionInventarioComponent,
        canActivate: [adminGuard],
    },
    {
        path: "mis-pedidos",
        component: MisPedidosComponent,
        canActivate: [clienteGuard],
    },
    {
        path: "mis-emprendimientos",
        component: GestionEmprendimientosComponent,
        canActivate: [clienteGuard],
    },
    {
        path: "mi-perfil/cliente/:tipo",
        component: NuevoRegistroComponent,
        canActivate: [clienteGuard],
    },

    {
        path: "mi-perfil/repartidor/:tipo",
        component: NuevoRegistroComponent,
        canActivate: [repartidorGuard],
    },
    { path: "ingresar2", component: Login2Component },
    { path: "foro", component: ForumComponent, canActivate: [combinedGuard] },
    {
        path: "foro/post/:id",
        component: PostComponent,
        canActivate: [combinedGuard],
    },
    {
        path: "foro/crearpost",
        component: CreatePostComponent,
        canActivate: [combinedGuard],
    },
    {
        path: "ordenes",
        component: OrdenesComponent,
        canActivate: [adminGuard],
    },
    {
        path: "ordenes/emprendimiento/:entrepeneurshipId",
        component: VerOrdenesEmprendedorComponent,
        canActivate: [emprendimientoGuard],
    },
    {
        path: "crear-orden",
        component: CrearOrdenComponent,
        canActivate: [adminGuard],
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes, {})],
    exports: [RouterModule],
})
export class AppRoutingModule {}
