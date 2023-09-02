CREATE TABLE DICT_NATIONALITY
(
	ID_CODE INTEGER PRIMARY KEY,
	VALUE_SHORT CHARACTER VARYING(60),
	VALUE_FULL CHARACTER VARYING(120),
	REMARKS CHARACTER VARYING(400)
);

COMMENT ON TABLE DICT_NATIONALITY IS 'Справочник типов гражданства';
COMMENT ON COLUMN DICT_NATIONALITY.ID_CODE IS 'Код значения справочника';
COMMENT ON COLUMN DICT_NATIONALITY.VALUE_SHORT IS 'Значение справочника сокращенное';
COMMENT ON COLUMN DICT_NATIONALITY.VALUE_FULL IS 'Значение справочника полное';
COMMENT ON COLUMN DICT_NATIONALITY.REMARKS IS 'Комментарии';

INSERT INTO DICT_NATIONALITY VALUES
	(1, 'РФ', 'Российская Федерация'),
	(2, 'США', 'Соединенные Штаты Америки'),
	(3, 'Грузия', 'Грузия'),
	(4, 'РБ', 'Республика Беларусь'),
	(5, 'Аремния', 'Армения');