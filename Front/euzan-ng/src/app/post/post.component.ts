import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import Swal from "sweetalert2";
import { ForumService } from "../services/forum.service";
import { Forum } from "../interfaces/forum";
import { SessionService } from "../services/session.service";

@Component({
    selector: "app-post",
    templateUrl: "./post.component.html",
    styleUrl: "./post.component.scss",
})
export class PostComponent {
    forumPost: Forum;
    admin: boolean = false;
    comment: string;
    constructor(
        private router: Router,
        private service: ForumService,
        private route: ActivatedRoute,
        private session: SessionService
    ) {
        this.service.get(route.snapshot.params.id).subscribe((data) => {
            this.forumPost = data;
        });
        this.admin = this.session.hasRole("ADMIN");
    }

    reload() {
        this.service.get(this.forumPost.Id).subscribe((data) => {
            this.forumPost = data;
        });
    }

    ngOnInit(): void {}

    addComment() {
        this.service
            .crearComentario(this.forumPost.Id, this.comment)
            .subscribe({
                next: (data) => {
                    this.reload();
                },
                error: (err) => {
                    this.service.errorMessage(err.error.Message);
                },
            });
    }

    deleteComment(id: number) {
        this.service.deleteComment(id).subscribe({
            next: (data) => {
                this.reload();
            },
            error: (err) => {
                this.service.errorMessage(err.error.Message);
            },
        });
    }

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
