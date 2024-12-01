import { Component } from "@angular/core";
import { Forum } from "../interfaces/forum";
import { Router } from "@angular/router";
import { ForumService } from "../services/forum.service";

@Component({
    selector: "app-create-post",
    templateUrl: "./create-post.component.html",
    styleUrl: "./create-post.component.scss",
})
export class CreatePostComponent {
    objeto: Forum = {
        Id: 0,
        Title: "",
        Description: "",
        Date: new Date(),
        location: "",
        AuthorId: 0,
        ForumComments: [],
        Usuario: "",
    };
    constructor(private router: Router, private service: ForumService) {}

    crearPost() {
        this.service.add(this.objeto).subscribe((data) => {
            console.log(data);
            this.router.navigate(["/foro"]);
        });
    }
}
