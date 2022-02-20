-- Table: public.users

-- DROP TABLE public.users;

CREATE TABLE IF NOT EXISTS public.users
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying COLLATE pg_catalog."default" NOT NULL,
    phone character varying NOT NULL,
    CONSTRAINT users_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE public.users
    OWNER to postgres;
	
-- Table: public.cards

-- DROP TABLE public.cards;

CREATE TABLE IF NOT EXISTS public.cards
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    user_id integer NOT NULL,
    title character varying COLLATE pg_catalog."default" NOT NULL,
    caption character varying COLLATE pg_catalog."default",
    date date NOT NULL,
    price integer,
    CONSTRAINT cards_pkey PRIMARY KEY (id),
    CONSTRAINT user_id FOREIGN KEY (user_id)
        REFERENCES public.users (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE public.cards
    OWNER to postgres;
	
-- Table: public.orders

-- DROP TABLE public.orders;

CREATE TABLE IF NOT EXISTS public.orders
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    customer_id integer NOT NULL,
    card_id integer NOT NULL,
    date date NOT NULL,
    CONSTRAINT orders_pkey PRIMARY KEY (id),
    CONSTRAINT card_pkey FOREIGN KEY (card_id)
        REFERENCES public.cards (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT customer_pkey FOREIGN KEY (customer_id)
        REFERENCES public.users (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE public.orders
    OWNER to postgres;

BEGIN;
INSERT INTO public.users(name, phone)
	VALUES ('John', '89991301551'), ('Penny', '89093402772'), ('Joey', '89110706333'), ('Maria', '89320004424'), ('Scot', '89080014555');
COMMIT;

BEGIN;
INSERT INTO public.cards(
	user_id, title, caption, date, price)
	VALUES 
	(1, 'Car', 'This is my car, my car is amazing!', '2022-01-29', '17000'),
	(1, 'Apartment', 'This is a communal, communal apartment', '2022-01-14', '33300'),
	(3, 'Winnie toy', 'My toy from my childhood', '2022-02-11', '2200'),
	(5, 'Lamp', 'I found it in the closet', '2022-02-02', '4100'),
	(3, 'Salad', 'Leftovers from last year''s salad', '2022-01-01', '50');
COMMIT;

BEGIN;
INSERT INTO public.orders(
	customer_id, card_id, date)
	VALUES 
	(2, 2, '2022-02-17'),
	(1, 5, '2022-01-02'),
	(2, 5, '2022-01-12'),
	(3, 5, '2022-01-01'),
	(5, 4, '2022-02-12');
COMMIT;