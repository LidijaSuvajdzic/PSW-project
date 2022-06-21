CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    CREATE TABLE "appointmentFeedback" (
        "Id" serial NOT NULL,
        "patientId" integer NOT NULL,
        grade integer NOT NULL,
        comment text NULL,
        "appointmentId" integer NOT NULL,
        CONSTRAINT "PK_appointmentFeedback" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    CREATE TABLE "freeAppointment" (
        id serial NOT NULL,
        "dateFrom" timestamp without time zone NOT NULL,
        "dateTo" timestamp without time zone NOT NULL,
        "doctorId" integer NOT NULL,
        "isFree" boolean NOT NULL,
        CONSTRAINT "PK_freeAppointment" PRIMARY KEY (id)
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    CREATE TABLE "hospitalFeedback" (
        "Id" serial NOT NULL,
        "patientId" integer NOT NULL,
        grade integer NOT NULL,
        comment text NULL,
        "isAnonymously" boolean NOT NULL,
        "isAPosted" boolean NOT NULL,
        CONSTRAINT "PK_hospitalFeedback" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    CREATE TABLE penals (
        "penalId" serial NOT NULL,
        "patientId" integer NOT NULL,
        date timestamp without time zone NOT NULL,
        CONSTRAINT "PK_penals" PRIMARY KEY ("penalId")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    CREATE TABLE prescription (
        id serial NOT NULL,
        "patientId" integer NOT NULL,
        "doctorId" integer NOT NULL,
        date timestamp without time zone NOT NULL,
        drug text NULL,
        usage text NULL,
        CONSTRAINT "PK_prescription" PRIMARY KEY (id)
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    CREATE TABLE referrals (
        id serial NOT NULL,
        "patientId" integer NOT NULL,
        "doctorId" integer NOT NULL,
        "specialistId" integer NOT NULL,
        reason text NULL,
        "dateFrom" timestamp without time zone NOT NULL,
        "dateTo" timestamp without time zone NOT NULL,
        CONSTRAINT "PK_referrals" PRIMARY KEY (id)
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    CREATE TABLE "reservedAppointment" (
        id serial NOT NULL,
        "dateFrom" timestamp without time zone NOT NULL,
        "dateTo" timestamp without time zone NOT NULL,
        "doctorId" integer NOT NULL,
        "patientId" integer NOT NULL,
        "isRated" boolean NOT NULL,
        CONSTRAINT "PK_reservedAppointment" PRIMARY KEY (id)
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    CREATE TABLE users (
        userid serial NOT NULL,
        firstname text NULL,
        lastname text NULL,
        email text NULL,
        password text NULL,
        healthcardnumber integer NOT NULL,
        role text NULL,
        "isBlocked" boolean NOT NULL,
        penals integer NOT NULL,
        "isPotentiallyMalicious" boolean NOT NULL,
        CONSTRAINT "PK_users" PRIMARY KEY (userid)
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    INSERT INTO "freeAppointment" (id, "dateFrom", "dateTo", "doctorId", "isFree")
    VALUES (1, TIMESTAMP '2022-06-20 13:00:00', TIMESTAMP '2022-06-20 14:00:00', 2, TRUE);
    INSERT INTO "freeAppointment" (id, "dateFrom", "dateTo", "doctorId", "isFree")
    VALUES (8, TIMESTAMP '2022-03-22 13:00:00', TIMESTAMP '2022-03-22 14:00:00', 6, TRUE);
    INSERT INTO "freeAppointment" (id, "dateFrom", "dateTo", "doctorId", "isFree")
    VALUES (7, TIMESTAMP '2022-06-29 15:00:00', TIMESTAMP '2022-06-29 16:00:00', 5, TRUE);
    INSERT INTO "freeAppointment" (id, "dateFrom", "dateTo", "doctorId", "isFree")
    VALUES (6, TIMESTAMP '2022-08-20 13:00:00', TIMESTAMP '2022-08-20 14:00:00', 3, TRUE);
    INSERT INTO "freeAppointment" (id, "dateFrom", "dateTo", "doctorId", "isFree")
    VALUES (9, TIMESTAMP '2022-09-20 13:00:00', TIMESTAMP '2022-09-20 14:00:00', 5, TRUE);
    INSERT INTO "freeAppointment" (id, "dateFrom", "dateTo", "doctorId", "isFree")
    VALUES (4, TIMESTAMP '2022-07-26 15:00:00', TIMESTAMP '2022-07-26 16:00:00', 4, TRUE);
    INSERT INTO "freeAppointment" (id, "dateFrom", "dateTo", "doctorId", "isFree")
    VALUES (3, TIMESTAMP '2022-07-25 15:00:00', TIMESTAMP '2022-07-25 16:00:00', 3, TRUE);
    INSERT INTO "freeAppointment" (id, "dateFrom", "dateTo", "doctorId", "isFree")
    VALUES (2, TIMESTAMP '2022-06-20 14:00:00', TIMESTAMP '2022-06-20 15:00:00', 2, TRUE);
    INSERT INTO "freeAppointment" (id, "dateFrom", "dateTo", "doctorId", "isFree")
    VALUES (5, TIMESTAMP '2022-03-30 13:00:00', TIMESTAMP '2022-03-30 14:00:00', 2, TRUE);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    INSERT INTO users (userid, email, firstname, healthcardnumber, "isBlocked", "isPotentiallyMalicious", lastname, password, penals, role)
    VALUES (7, 'kristina@gmail.com', 'Kristina', 111154321, FALSE, FALSE, 'Peric', '1234567890', 0, 'PATIENT');
    INSERT INTO users (userid, email, firstname, healthcardnumber, "isBlocked", "isPotentiallyMalicious", lastname, password, penals, role)
    VALUES (1, 'suvajdziclidija@gmail.com', 'Lidija', 1234567890, FALSE, FALSE, 'Suvajdzic', '1234567890', 0, 'ADMIN');
    INSERT INTO users (userid, email, firstname, healthcardnumber, "isBlocked", "isPotentiallyMalicious", lastname, password, penals, role)
    VALUES (2, 'draganaarsin97@gmail.com', 'Dragana', 987654321, FALSE, FALSE, 'Arsin', '1234567890', 0, 'DOCTOR');
    INSERT INTO users (userid, email, firstname, healthcardnumber, "isBlocked", "isPotentiallyMalicious", lastname, password, penals, role)
    VALUES (3, 'milicaperic@gmail.com', 'Milica', 111154321, FALSE, FALSE, 'Peric', '1234567890', 0, 'DOCTOR');
    INSERT INTO users (userid, email, firstname, healthcardnumber, "isBlocked", "isPotentiallyMalicious", lastname, password, penals, role)
    VALUES (4, 'simonidasimic@gmail.com', 'Simonida', 982222321, FALSE, FALSE, 'Simic', '1234567890', 0, 'DOCTOR');
    INSERT INTO users (userid, email, firstname, healthcardnumber, "isBlocked", "isPotentiallyMalicious", lastname, password, penals, role)
    VALUES (5, 'sanja@gmail.com', 'Sanja', 111154321, FALSE, FALSE, 'Peric', '1234567890', 0, 'SPECIALIST');
    INSERT INTO users (userid, email, firstname, healthcardnumber, "isBlocked", "isPotentiallyMalicious", lastname, password, penals, role)
    VALUES (6, 'stefan@gmail.com', 'Stefan', 982222321, FALSE, FALSE, 'Simic', '1234567890', 0, 'SPECIALIST');
    INSERT INTO users (userid, email, firstname, healthcardnumber, "isBlocked", "isPotentiallyMalicious", lastname, password, penals, role)
    VALUES (8, 'esma@gmail.com', 'Esma', 982222321, FALSE, FALSE, 'Simic', '1234567890', 0, 'PATIENT');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621010930_newOnee') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220621010930_newOnee', '2.2.4-servicing-10062');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621011056_newOneee') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220621011056_newOneee', '2.2.4-servicing-10062');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621111903_cao') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220621111903_cao', '2.2.4-servicing-10062');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220621113554_caoo') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220621113554_caoo', '2.2.4-servicing-10062');
    END IF;
END $$;
