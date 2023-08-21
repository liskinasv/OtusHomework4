CREATE DATABASE Avito;

CREATE TABLE Users(
	user_id SERIAL PRIMARY KEY,
	username VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL
);

CREATE TABLE Category(
	category_id SERIAL PRIMARY KEY,
	name VARCHAR(50) NOT NULL
);


CREATE TABLE Subcategory(
	subcategory_id SERIAL PRIMARY KEY,
	category_id INT REFERENCES Category(category_id), 
	name VARCHAR(50) NOT NULL
);

CREATE TABLE Advertisements(
	ad_id SERIAL PRIMARY KEY,
	user_id INT REFERENCES Users(user_id),
	subcategory_id INT REFERENCES Subcategory(subcategory_id),
	title VARCHAR(100) NOT NULL,
	description TEXT
);


INSERT INTO public.category(
	category_id, name)
	VALUES (1, 'Транспорт');

INSERT INTO public.category(
	category_id, name)
	VALUES (2, 'Недвижимость');

INSERT INTO public.category(
	category_id, name)
	VALUES (3, 'Работа');

INSERT INTO public.category(
	category_id, name)
	VALUES (4, 'Электроника');

INSERT INTO public.category(
	category_id, name)
	VALUES (5, 'Животные');


INSERT INTO public.subcategory(
	subcategory_id, category_id, name)
	VALUES (1, 1, 'Audi');

INSERT INTO public.subcategory(
	subcategory_id, category_id, name)
	VALUES (2, 1, 'BMW');

INSERT INTO public.subcategory(
	subcategory_id, category_id, name)
	VALUES (3, 1, 'Ford');

INSERT INTO public.subcategory(
	subcategory_id, category_id, name)
	VALUES (4, 4, 'Мобильные телефоны');

INSERT INTO public.subcategory(
	subcategory_id, category_id, name)
	VALUES (5, 5, 'Собаки');


INSERT INTO public.users(
	user_id, username, email)
	VALUES (1, 'Мария Иванована', 'marivana@mail.ru');


INSERT INTO public.users(
	user_id, username, email)
	VALUES (2, 'Иван Сергеевич', 'ivan@mail.ru');

INSERT INTO public.users(
	user_id, username, email)
	VALUES (3, 'Петя Сидоров', 'petia@mail.ru');

INSERT INTO public.users(
	user_id, username, email)
	VALUES (4, 'Александр Александрович', 'alex@mail.ru');

INSERT INTO public.users(
	user_id, username, email)
	VALUES (5, 'Елена', 'alena@mail.ru');


INSERT INTO public.advertisements(
	ad_id, user_id, subcategory_id, title, description)
	VALUES (1, 1, 5, 'Метис бордер-колли ангельской красоты в дар', 'Белоснежная красавица Долли в ожидании дома и самой любящей семьи!');

INSERT INTO public.advertisements(
	ad_id, user_id, subcategory_id, title, description)
	VALUES (2, 2, 5, 'Карликовый пудель девочка', 'Девочка карликовый пудель серебристого окраса, все документы ');
	
INSERT INTO public.advertisements(
	ad_id, user_id, subcategory_id, title, description)
	VALUES (3, 3, 4, 'iPhone 14 Pro max 256 гб', 'Никаких восстановленных и обменок, только новый');
		
INSERT INTO public.advertisements(
	ad_id, user_id, subcategory_id, title, description)
	VALUES (4, 4, 4, 'Apple iPhone 13 оригинал', 'Пoдaрки к каждой покупке:защитное стекло+чехол');
	
INSERT INTO public.advertisements(
	ad_id, user_id, subcategory_id, title, description)
	VALUES (5, 5, 1, 'Audi Q7 3.0 AT, 2020, 55 000 км', 'AUDI Q7 45TDI - ИЗ ГЕРМАНИИ !!!');
	



