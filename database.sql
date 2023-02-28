ALTER TABLE "public"."rer_project_person" DROP CONSTRAINT "FK_rer_project_person_project_id";
ALTER TABLE "public"."rer_project_person" DROP CONSTRAINT "FK_rer_project_person_person_id";
DROP TABLE IF EXISTS "public"."rer_project";
DROP TABLE IF EXISTS "public"."rer_person";
DROP TABLE IF EXISTS "public"."rer_project_person";
CREATE TABLE "public"."rer_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "rer_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."rer_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "rer_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."rer_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "rer_project_person_pkey" PRIMARY KEY ("id")
);
ALTER TABLE "public"."rer_project_person" ADD CONSTRAINT "FK_rer_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."rer_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."rer_project_person" ADD CONSTRAINT "FK_rer_project_person_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."rer_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;