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

CREATE TABLE book_genres (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);
CREATE TABLE library_resources (
    resource_id SERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255),
    total_copies INT NOT NULL,
    available_copies INT NOT NULL,
    isbn VARCHAR(20) UNIQUE,
    publication_year INT,
    genre VARCHAR(100),
    publisher VARCHAR(255),
    description TEXT
);

INSERT INTO book_genres (name) VALUES ('Fiction');
INSERT INTO book_genres (name) VALUES ('Non-Fiction');
INSERT INTO book_genres (name) VALUES ('Mystery');
INSERT INTO book_genres (name) VALUES ('Science Fiction');
INSERT INTO book_genres (name) VALUES ('Fantasy');
INSERT INTO book_genres (name) VALUES ('Romance');
INSERT INTO book_genres (name) VALUES ('Thriller');
INSERT INTO book_genres (name) VALUES ('Biography');
INSERT INTO book_genres (name) VALUES ('History');
INSERT INTO book_genres (name) VALUES ('Self-Help');
INSERT INTO book_genres (name) VALUES ('Newspaper');