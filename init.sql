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

INSERT INTO public.users (id, firstname, lastname, username, email, phonenumber, "role", "password") VALUES(21, 'Precious', 'Precious', 'PreciousNyasulu', 'preciousnyasulu441@gmail.com', '+265993685560', '0', 'b065a233-9dde-46e5-a7d5-028e34ba7832AQAAAAIAAYagAAAAEEPkIH1s6B9wSLRvuluvzEe612SjXUzdszXpZCC/2+qZS/7H1HqlLbqFPvFVCJy9yA==');


CREATE TABLE book_genres (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE library_resources (
	resource_id serial4 NOT NULL,
	title varchar(255) NOT NULL,
	author varchar(255) NULL,
	total_copies int4 NOT NULL,
	available_copies int4 NOT NULL,
	isbn varchar(20) NULL,
	publication_year int4 NULL,
	genre int4 NULL,
	publisher varchar(255) NULL,
	description text NULL,
	CONSTRAINT library_resources_isbn_key UNIQUE (isbn),
	CONSTRAINT library_resources_pkey PRIMARY KEY (resource_id)
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

INSERT INTO library_resources (title, author, total_copies, available_copies, isbn, publication_year, genre, publisher, description)
VALUES
    ('The Great Gatsby', 'F. Scott Fitzgerald', 5, 3, '978-3-16-148410-0', 1925, (SELECT id FROM book_genres WHERE name = 'Fiction'), 'Scribner', 'A novel about the American Dream'),
    ('To Kill a Mockingbird', 'Harper Lee', 8, 5, '978-0-06-112008-4', 1960, (SELECT id FROM book_genres WHERE name = 'Fiction'), 'J.B. Lippincott & Co.', 'A classic of modern American literature'),
    ('1984', 'George Orwell', 6, 4, '978-0-452-28423-4', 1949, (SELECT id FROM book_genres WHERE name = 'Science Fiction'), 'Secker & Warburg', 'A dystopian novel'),
    ('The Catcher in the Rye', 'J.D. Salinger', 7, 2, '978-0-316-76948-0', 1951, (SELECT id FROM book_genres WHERE name = 'Fiction'), 'Little, Brown and Company', 'A novel about teenage angst and alienation'),
    ('The Hobbit', 'J.R.R. Tolkien', 10, 8, '978-0-618-51740-1', 1937, (SELECT id FROM book_genres WHERE name = 'Fantasy'), 'Allen & Unwin', 'A fantasy novel'),
    ('Pride and Prejudice', 'Jane Austen', 5, 5, '978-1-59308-324-2', 1813, (SELECT id FROM book_genres WHERE name = 'Romance'), 'T. Egerton, Whitehall', 'A romantic novel'),
    ('The Da Vinci Code', 'Dan Brown', 12, 10, '978-0-385-50420-4', 2003, (SELECT id FROM book_genres WHERE name = 'Mystery'), 'Doubleday', 'A mystery thriller'),
    ('The Hitchhiker''s Guide to the Galaxy', 'Douglas Adams', 8, 6, '978-0-345-39180-3', 1979, (SELECT id FROM book_genres WHERE name = 'Science Fiction'), 'Pan Books', 'A comedic science fiction series'),
    ('Harry Potter and the Sorcerer''s Stone', 'J.K. Rowling', 15, 12, '978-0-7475-3269-6', 1997, (SELECT id FROM book_genres WHERE name = 'Fantasy'), 'Bloomsbury', 'The first book in the Harry Potter series'),
    ('The Girl with the Dragon Tattoo', 'Stieg Larsson', 9, 7, '978-0-307-27536-0', 2005, (SELECT id FROM book_genres WHERE name = 'Mystery'), 'Norstedts Förlag', 'A psychological thriller'),
     ('Daily Times', 'Various Authors', 20, 18, 'N/A', 2024, (SELECT id FROM book_genres WHERE name = 'Newspaper'), 'Local Press', 'Daily news articles covering local and international events');

CREATE TABLE members (
    member_id SERIAL PRIMARY KEY,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    email VARCHAR(255),
    phone_number VARCHAR(15),
    address TEXT,
    registration_date TIMESTAMP NOT NULL
);

CREATE TABLE borrow_history (
    borrow_id SERIAL PRIMARY KEY,
    member_id INT REFERENCES members(member_id),
    resource_id INT REFERENCES library_resources(resource_id),
    borrow_date TIMESTAMP NOT NULL,
    return_date TIMESTAMP,
    CONSTRAINT unique_borrow UNIQUE (member_id, resource_id)
);
