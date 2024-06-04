
CREATE TABLE IF NOT EXISTS TARGET_AUDIENCE (
    target_audience_id INTEGER PRIMARY KEY,
    target_audience_name VARCHAR(20) NOT NULL
);

CREATE TABLE LOCATION (
    id_location INTEGER PRIMARY KEY,
    location_name VARCHAR(20) NOT NULL
);
CREATE TABLE RACE (
    race_id INTEGER PRIMARY KEY,
    race_name VARCHAR(25) NOT NULL
);
CREATE TABLE VOICE (
    voice_id INTEGER PRIMARY KEY,
    voice_name VARCHAR(20) NOT NULL
);

CREATE TABLE DEPARTMENTS (
    department_id INTEGER PRIMARY KEY,
    department_name VARCHAR(100) NOT NULL
);
CREATE TABLE EMPLOYEES (
    employee_id INTEGER PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    surname VARCHAR(30) NOT NULL,
    patronymic VARCHAR(20),
    department_id INT REFERENCES DEPARTMENTS(department_id),
    hire_date DATE NOT NULL,
    dismissal_date DATE,
    employees_gender VARCHAR(10) NOT NULL,
    employees_date_birth DATE NOT NULL,
    count_child INTEGER DEFAULT 0 NOT NULL,
    salary INTEGER NOT NULL
);
CREATE TABLE ROLES (
    role_id INTEGER PRIMARY KEY,
    characters INTEGER[] REFERENCES CHARACTERS(characters_id),
    actor INTEGER[] REFERENCES ACTORS(actor_id),
    double BOOLEAN DEFAULT FALSE,
    performance_name INTEGER REFERENCES PERFORMANCE(performance_id)
);
CREATE TABLE PLAYS (
    play_id INTEGER PRIMARY KEY,
    plays_name VARCHAR(30) NOT NULL,
    plays_genre INTEGER[] REFERENCES GENRE(genre_id),
    plays_target_audience INTEGER[] REFERENCES TARGET_AUDIENCE(target_audience_id),
    date_creation DATE,
    author_name INTEGER REFERENCES AUTHORS(authors_id)
);
CREATE TABLE CHARACTERS (
    characters_id INTEGER PRIMARY KEY,
    characters_name VARCHAR(20) NOT NULL,
    characters_height_min INTEGER NOT NULL,
    characters_height_max INTEGER NOT NULL,
    characters_speice INTEGER REFERENCES RACE(race_id),
    characters_gender VARCHAR(10) NOT NULL,
    characters_voice INTEGER REFERENCES VOICE(voice_id),
    characters_plays INTEGER[] REFERENCES PLAYS(play_id)
);
CREATE TABLE ACTORS (
    actor_id INTEGER PRIMARY KEY,
    employee INTEGER REFERENCES EMPLOYEES(employee_id),
    voice INTEGER REFERENCES VOICE(voice_id),
    species INTEGER REFERENCES RACE(race_id),
    height INTEGER NOT NULL
);
CREATE TABLE ACHIEVEMENTS (
    achievement_id INTEGER PRIMARY KEY,
    employee_id INTEGER[] REFERENCES EMPLOYEES(employee_id),
    achivment_name VARCHAR(20) NOT NULL,
    achiment_date DATE NOT NULL
);
CREATE TABLE TOUR (
    tour_id INTEGER PRIMARY KEY,
    theater_from VARCHAR(30) NOT NULL,
    theater_where VARCHAR(30) NOT NULL,
    tour_plays INTEGER REFERENCES PLAYS(play_id),
    tour_employees INTEGER[] REFERENCES EMPLOYEES(employee_id),
    date_start DATE NOT NULL,
    date_end DATE NOT NULL
);

CREATE TABLE IF NOT EXISTS GENRE (
    genre_id INTEGER PRIMARY KEY,
    genre_name VARCHAR(20) NOT NULL
);
CREATE TABLE PERFORMANCE (
    performance_id INTEGER PRIMARY KEY,
    date TIMESTAMP NOT NULL,
    plays_name INTEGER REFERENCES PLAYS(play_id),
    premiere BOOLEAN DEFAULT TRUE,
    producer INTEGER REFERENCES EMPLOYEES(employee_id),
    conductor INTEGER REFERENCES EMPLOYEES(employee_id),
    art_director INTEGER REFERENCES EMPLOYEES(employee_id),
    base_cost INTEGER NOT NULL
);
CREATE TABLE AUTHORS (
    authors_id INTEGER PRIMARY KEY,
    authors_name VARCHAR(20) NOT NULL,
    authors_surname VARCHAR(30) NOT NULL,
    date_birth DATE NOT NULL,
    country VARCHAR(25)
);
CREATE TABLE CONTEST (
    contest_id INTEGER PRIMARY KEY,
    contest_name VARCHAR(20) NOT NULL,
    contest_place INTEGER,
    contest_employe INTEGER[] REFERENCES EMPLOYEES(employee_id),
    contest_date DATE NOT NULL
);
CREATE TABLE TICKETS (
    tickets_id INTEGER PRIMARY KEY,
    ticket_place INTEGER REFERENCES PLACES(places_id),
    ticket_performance INTEGER[] REFERENCES PERFORMANCE(performance_id),
    cost INTEGER NOT NULL
);
CREATE TABLE PLACES (
    places_id INTEGER PRIMARY KEY,
    number_place INTEGER NOT NULL,
    number_row INTEGER NOT NULL,
    place_location INTEGER REFERENCES LOCATION(id_location),
    place_cost INTEGER NOT NULL
);

INSERT INTO TARGET_AUDIENCE (target_audience_name)
VALUES ('Children'), ('Teenagers'), ('Adults'), ('Elderly');

INSERT INTO DEPARTMENTS (department_name)
VALUES
    ('Administration'),
    ('Marketing'),
    ('Finance'),
    ('HR'),
    ('Actors'),
    ('Directors'),
    ('Stage Design'),
    ('Costume Design'),
    ('Lighting Design'),
    ('Sound Design'),
    ('Stage Management'),
    ('Public Relations'),
    ('Ticketing'),
    ('Catering');
INSERT INTO DEPARTMENTS (department_name)
VALUES
    ('Producer'),
    ('Conductor'),
    ('Art-Director');


INSERT INTO EMPLOYEES (name, surname, patronymic, department_id, hire_date, dismissal_date, employees_gender, employees_date_birth, count_child, salary)
VALUES
    ('John', 'Doe', 'Smith', 1, '2022-01-15', NULL, 'Male', '1990-05-20', 0, 50000),
    ('Alice', 'Johnson', NULL, 2, '2022-02-20', NULL, 'Female', '1995-08-12', 1, 45000),
    ('Michael', 'Williams', 'Robert', 3, '2021-11-10', NULL, 'Male', '1985-03-25', 2, 60000);

INSERT INTO GENRE (genre_name)
VALUES ('Tragedy'), ('Comedy'), ('Drama'), ('Historical');

INSERT INTO AUTHORS (authors_name, authors_surname, date_birth, country)
VALUES
    ('William', 'Shakespeare', '1564-04-23', 'England'),
    ('Johann', 'Goethe', '1749-08-28', 'Germany'),
    ('Fyodor', 'Dostoevsky', '1821-11-11', 'Russia');


INSERT INTO EMPLOYEES (name, surname, patronymic, department_id, hire_date, employees_gender, employees_date_birth, count_child, salary)
VALUES
    ('David', 'Smith', 'John', 5, '2022-03-01', 'Male', '1992-07-15', 0, 70000),
    ('Emily', 'Brown', 'Maria', 5, '2022-03-05', 'Female', '1998-04-30', 0, 70000),
    ('Matthew', 'Wilson', NULL, 6, '2022-02-28', 'Male', '1980-12-10', 2, 80000),
    ('Sophia', 'Jones', 'Anne', 15, '2022-02-25', 'Female', '1985-06-20', 1, 80000),
    ('Daniel', 'Miller', 'Thomas', 16, '2022-03-10', 'Male', '1983-09-05', 1, 70000),
    ('Olivia', 'Taylor', NULL, 17, '2022-03-12', 'Female', '1988-01-15', 2, 70000);

INSERT INTO VOICE (voice_name)
VALUES ('Bass'), ('Baritone'), ('Tenor'), ('Alto'), ('Soprano');

INSERT INTO RACE (race_name)
VALUES ('Caucasian'), ('African'), ('Asian'), ('Latino');

INSERT INTO ACTORS (employee, voice, species, height)
VALUES
    (4, 1, 1, 180),
    (5, 2, 2, 165);

INSERT INTO ACHIEVEMENTS (employee_id, achivment_name, achiment_date)
VALUES
    (4, 'Best Actor Award', '2023-05-20'),
    (5, 'Best Actress Award', '2023-06-10');

INSERT INTO CONTEST (contest_name, contest_place, contest_employe, contest_date)
VALUES
    ('Acting Competition', 1, 1, '2023-05-20'),
    ('Theater Design Contest', 2, 3, '2023-06-10'),
    ('Best Director Award', 1, 5, '2023-07-25');

INSERT INTO LOCATION (location_name)
VALUES ('Main hall'), ('Balcony'), ('Box seats');

INSERT INTO PLAYS (plays_name, plays_genre, plays_target_audience, date_creation, author_name)
VALUES
    ('Hamlet', 1, 3, '2021-10-01', 1),
    ('Romeo and Juliet', 1, 2, '2021-09-15', 2),
    ('Macbeth', 2, 1, '2022-01-05', 3);

INSERT INTO CHARACTERS (characters_name, characters_height_min, characters_height_max, characters_speice, characters_gender, characters_voice, characters_plays)
VALUES
    ('Hamlet', 170, 180, 1, 'Male', 3, 1),
    ('Ophelia', 160, 170, 1, 'Female', 4, 1),
    ('Romeo', 170, 180, 1, 'Male', 5, 2),
    ('Juliet', 160, 170, 1, 'Female', 6, 2),
    ('Macbeth', 170, 180, 1, 'Male', 3, 3),
    ('Lady Macbeth', 160, 170, 1, 'Female', 4, 3);

INSERT INTO PERFORMANCE (date, plays_name, premiere, producer, conductor, art_director, base_cost)
VALUES
    ('2022-04-15 19:00:00', 1, TRUE, 15, 16, 17, 5000),
    ('2022-05-20 18:30:00', 2, FALSE, 15, 16, 17, 5500),
    ('2022-06-10 20:00:00', 3, TRUE, 15, 16, 17, 6000);

INSERT INTO PLACES (number_place, number_row, place_location, place_cost)
VALUES
    (1, 1, 1, 1000),
    (2, 2, 1, 1000),
    (1, 1, 2, 1200),
    (2, 2, 2, 1200),
    (1, 1, 3, 1500),
    (2, 2, 3, 1500);

INSERT INTO TICKETS (ticket_place, ticket_performance, cost)
VALUES
    (1, 1, 1500),
    (2, 1, 1500),
    (3, 2, 1000),
    (4, 2, 1000),
    (1, 3, 1500),
    (2, 3, 1500);

INSERT INTO TOUR (theater_from, theater_where, tour_plays, tour_employees, date_start, date_end)
VALUES
    ('Big Theater', 'Theater A', 1, 1, '2022-05-01', '2022-05-07'),
    ('Theater B', 'Big Theater', 2, 5, '2022-05-03', '2022-05-09'),
    ('Theater C', 'Big Theater', 3, 7, '2022-05-05', '2022-05-11');

INSERT INTO ROLES (characters, actor, double, performance_name)
VALUES
    (1, 1, FALSE, 1),
    (2, 2, FALSE, 1),
    (3, 1, TRUE, 2);

INSERT INTO ROLES (characters, actor, double, performance_name)
VALUES
    (3, 2, FALSE, 2);


