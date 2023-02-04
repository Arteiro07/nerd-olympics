import { Url } from "url";

export type User = {
    id: number;
    firstName: string;
    lastName: string;
    age: number;
    gender: string;
    image:string;
};

export type UserDetailed = {
    id: number;
    firstName: string;
    lastName: string;
    age: number;
    gender: string;
    email:string;
    height:number;
    width:number;
    eyeColor:string;
    image:string;
};

export type CompetitionDto = {
    id: number;
    title: string;
    description: string;
    createdDate: Date;
};