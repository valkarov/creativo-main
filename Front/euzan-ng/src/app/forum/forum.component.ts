import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { ForumService } from "../services/forum.service";
import { Forum } from "../interfaces/forum";
import Swal from "sweetalert2";

@Component({
    selector: "app-forum",
    templateUrl: "./forum.component.html",
    styleUrl: "./forum.component.scss",
})
export class ForumComponent {
    forumPost: Forum[] = [];
    constructor(private router: Router, private service: ForumService) {
        this.service.getList().subscribe((data) => {
            this.forumPost = data;
        });
    }

    ngOnInit(): void {}

    redirigir(url: string) {
        this.router.navigate([url]);
    }
    visitarPost(id: number) {
        this.router.navigate(["/foro/post", id]);
    }
    deletePost(id: number) {
        Swal.fire({
            title: "¿Quieres eliminar este Post del foro?",
            text: "¡No lo vas a poder revertir!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Eliminar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.service.delete(id).subscribe({
                    next: (data) => {
                        this.service.successMessage(
                            "El administrador se ha eliminado correctamente",
                            "/foro"
                        );
                    },
                    error: (err) => {
                        this.service.errorMessage(err.error.Message);
                    },
                });
            }
        });
    }
}
