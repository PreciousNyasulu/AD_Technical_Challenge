CREATE TABLE public.users (
    id SERIAL PRIMARY KEY,
    firstname varchar NULL,
    lastname varchar NULL,
    username varchar NULL,
    email varchar NULL,
    phonenumber varchar NULL,
    "role" varchar NULL,
    "password" varchar NULL
);


CREATE SEQUENCE basic_sequence
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;