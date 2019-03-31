
CREATE DATABASE psql_identity
    WITH 
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;
	
\connect psql_identity
   
CREATE TABLE public.role_claims (
    id bigint NOT NULL,
    role_id uuid NOT NULL,
    claim_type text NOT NULL,
    claim_value text NOT NULL
);

CREATE SEQUENCE public.role_claims_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;

ALTER SEQUENCE public.role_claims_id_seq OWNED BY public.role_claims.id;

ALTER TABLE ONLY public.role_claims
    ADD CONSTRAINT role_claims_pkey PRIMARY KEY (id);

CREATE TABLE public.roles (
    id uuid NOT NULL,
    name text NOT NULL,
    normalized_name text,
    concurrency_stamp text
);

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (id);
	
ALTER TABLE ONLY public.role_claims
    ADD CONSTRAINT role_claims_role_id_refs_roles_id FOREIGN KEY (role_id) REFERENCES public.roles(id);

CREATE TABLE public.user_claims (
    id bigint NOT NULL,
    user_id uuid NOT NULL,
    claim_type text NOT NULL,
    claim_value text NOT NULL
);

CREATE SEQUENCE public.user_claims_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
	
ALTER SEQUENCE public.user_claims_id_seq OWNED BY public.user_claims.id;

ALTER TABLE ONLY public.user_claims
    ADD CONSTRAINT user_claims_pkey PRIMARY KEY (id);

CREATE TABLE public.user_logins (
    user_id uuid NOT NULL,
    login_provider text NOT NULL,
    provider_key text NOT NULL,
    provider_display_name text NOT NULL
);

ALTER TABLE ONLY public.user_logins
    ADD CONSTRAINT user_logins_pkey PRIMARY KEY (user_id);

CREATE TABLE public.user_roles (
    user_id uuid NOT NULL,
    role_id uuid NOT NULL
);

ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT user_roles_pkey PRIMARY KEY (user_id, role_id);

CREATE TABLE public.user_tokens (
    user_id uuid NOT NULL,
    login_provider text NOT NULL,
    name text NOT NULL,
    value text NOT NULL
);

ALTER TABLE ONLY public.user_tokens
    ADD CONSTRAINT user_tokens_pkey PRIMARY KEY (user_id);

CREATE TABLE public.users (
    id uuid NOT NULL,
    lockout_end timestamp with time zone,
    two_factor_enabled boolean,
    phone_number_confirmed boolean,
    phone_number text,
    concurrency_stamp text,
    security_stamp text,
    password_hash text,
    email_confirmed boolean,
    normalized_email text,
    email text,
    normalized_user_name text,
    user_name text,
    lockout_enabled boolean,
    access_failed_count integer
);

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_index_id PRIMARY KEY (id);
	
ALTER TABLE ONLY public.user_claims
    ADD CONSTRAINT user_claims_user_id_refs_users_id FOREIGN KEY (user_id) REFERENCES public.users(id);
	
ALTER TABLE ONLY public.user_logins
    ADD CONSTRAINT user_logins_user_id_refs_users_id FOREIGN KEY (user_id) REFERENCES public.users(id);
	
ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT user_roles_role_id_refs_roles_id FOREIGN KEY (role_id) REFERENCES public.roles(id);
	
ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT user_roles_user_id_refs_users_id FOREIGN KEY (user_id) REFERENCES public.users(id);

ALTER TABLE ONLY public.user_tokens
    ADD CONSTRAINT user_tokens_user_id_refs_users_id FOREIGN KEY (user_id) REFERENCES public.users(id);


ALTER TABLE ONLY public.role_claims ALTER COLUMN id SET DEFAULT nextval('public.role_claims_id_seq'::regclass);

ALTER TABLE ONLY public.user_claims ALTER COLUMN id SET DEFAULT nextval('public.user_claims_id_seq'::regclass);
