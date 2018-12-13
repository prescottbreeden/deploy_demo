-- CREATE SCHEMA
DROP SCHEMA IF EXISTS wedding_planner;

CREATE SCHEMA wedding_planner
DEFAULT CHARACTER SET utf8;

USE wedding_planner;

-- CREATE TABLES

CREATE TABLE IF NOT EXISTS users (
  user_id         INTEGER       NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name            VARCHAR(50)   NOT NULL,
  email           VARCHAR(90)   NOT NULL,
  password        VARCHAR(255)  NOT NULL,
  created_at      DATETIME      NOT NULL  DEFAULT NOW(),
  updated_at      DATETIME      NOT NULL  DEFAULT NOW() ON UPDATE NOW()
);

CREATE TABLE IF NOT EXISTS addresses (
  address_id      INTEGER       NOT NULL AUTO_INCREMENT PRIMARY KEY,
  street          VARCHAR(255)  NOT NULL,
  city            VARCHAR(50)   NOT NULL,
  state           VARCHAR(3)    NOT NULL,
  zip_code        INTEGER(11)   NOT NULL
);

CREATE TABLE IF NOT EXISTS weddings (
  wedding_id      INTEGER       NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_id         INTEGER       NOT NULL,
  address_id      INTEGER       NOT NULL,
  wedder_one      VARCHAR(50)   NOT NULL,
  wedder_two      VARCHAR(50)   NOT NULL,
  wedding_date    DATETIME      NOT NULL,
  created_at      DATETIME      NOT NULL  DEFAULT NOW(),
  updated_at      DATETIME      NOT NULL  DEFAULT NOW() ON UPDATE NOW(),

  FOREIGN KEY (user_id)
    REFERENCES users(user_id),
  FOREIGN KEY (address_id)
    REFERENCES addresses(address_id)
);

CREATE TABLE IF NOT EXISTS guests (
  guest_id        INTEGER       NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_id         INTEGER       NOT NULL,
  wedding_id      INTEGER       NOT NULL,

  FOREIGN KEY (user_id)
    REFERENCES users(user_id),

  FOREIGN KEY (wedding_id)
    REFERENCES weddings(wedding_id)
)
