CREATE TABLE DICT_CLIENT_TYPE
(
	ID_CODE INTEGER PRIMARY KEY,
	VALUE_SHORT CHARACTER VARYING(60),
	VALUE_FULL CHARACTER VARYING(120),
	REMARKS CHARACTER VARYING(400)
);

COMMENT ON TABLE DICT_CLIENT_TYPE IS 'Справочник типов клиентов';
COMMENT ON COLUMN DICT_CLIENT_TYPE.ID_CODE IS 'Код значения справочника';
COMMENT ON COLUMN DICT_CLIENT_TYPE.VALUE_SHORT IS 'Значение справочника сокращенное';
COMMENT ON COLUMN DICT_CLIENT_TYPE.VALUE_FULL IS 'Значение справочника полное';
COMMENT ON COLUMN DICT_CLIENT_TYPE.REMARKS IS 'Комментарии';

INSERT INTO DICT_CLIENT_TYPE VALUES
	(1, 'Физ.лицо', 'Физическое лицо'),
	(2, 'Юр.лицо', 'Юридическое лицо'),
	(3, 'ИП', 'Индивидуальный предприниматель');