export interface PreguntaInterface {
    Id: number;
    QuestionText: string;
    Answer: string;
}

export class Pregunta implements PreguntaInterface {
    Id!: number;
    QuestionText!: string;
    Answer!: string;
}
