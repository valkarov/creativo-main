export interface Forum {
    Id: number;
    Title: string;
    Description: string;
    Date: Date;
    location: string;
    AuthorId: number;
    ForumComments: ForumComment[];
    Usuario: string;
    IsYours?: boolean;
}

export interface ForumComment {
    id: number;
    Comment: string;
    date: Date;
    forumId: number;
    authorId: number;
    usuario: string;
    IsYours?: boolean;
}
