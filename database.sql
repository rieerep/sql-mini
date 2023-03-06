ALTER TABLE "public"."rer_project_person" DROP CONSTRAINT "FK_rer_project_person_project_id";
ALTER TABLE "public"."rer_project_person" DROP CONSTRAINT "FK_rer_project_person_person_id";
DROP TABLE IF EXISTS "public"."rer_project";
DROP TABLE IF EXISTS "public"."rer_project_person";
DROP TABLE IF EXISTS "public"."rer_person";
CREATE TABLE "public"."rer_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "rer_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."rer_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "rer_project_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."rer_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "rer_person_pkey" PRIMARY KEY ("id")
);
INSERT INTO "public"."rer_project" ("project_name") VALUES ('mini project');
INSERT INTO "public"."rer_project" ("project_name") VALUES ('Read books');
INSERT INTO "public"."rer_project" ("project_name") VALUES ('Booking system');
INSERT INTO "public"."rer_project" ("project_name") VALUES ('website database');
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 3);
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 10);
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (1, 2, 3);
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (3, 4, 10);
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (3, 3, 0);
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (3, 4, 10);
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (2, 7, 4);
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (3, 4, 12);
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (4, 8, 3);
INSERT INTO "public"."rer_project_person" ("project_id", "person_id", "hours") VALUES (2, 2, 3);
INSERT INTO "public"."rer_person" ("person_name") VALUES ('Erkan');
INSERT INTO "public"."rer_person" ("person_name") VALUES ('Freja');
INSERT INTO "public"."rer_person" ("person_name") VALUES ('Tomas');
INSERT INTO "public"."rer_person" ("person_name") VALUES ('James');
INSERT INTO "public"."rer_person" ("person_name") VALUES ('Hannah');
INSERT INTO "public"."rer_person" ("person_name") VALUES ('clyde');
ALTER TABLE "public"."rer_project_person" ADD CONSTRAINT "FK_rer_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."rer_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."rer_project_person" ADD CONSTRAINT "FK_rer_project_person_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."rer_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
