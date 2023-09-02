CREATE TABLE DICT_CURRENCY
(
	ID_CODE INTEGER PRIMARY KEY,
	VALUE_SHORT CHARACTER VARYING(60),
	VALUE_FULL CHARACTER VARYING(120),
	REMARKS CHARACTER VARYING(400)
);

COMMENT ON TABLE DICT_CURRENCY IS 'Справочник типов валют';
COMMENT ON COLUMN DICT_CURRENCY.ID_CODE IS 'Код значения справочника';
COMMENT ON COLUMN DICT_CURRENCY.VALUE_SHORT IS 'Значение справочника сокращенное';
COMMENT ON COLUMN DICT_CURRENCY.VALUE_FULL IS 'Значение справочника полное';
COMMENT ON COLUMN DICT_CURRENCY.REMARKS IS 'Комментарии';

INSERT INTO DICT_CURRENCY VALUES
	(1, 'RUB', 'Российский рубль'),
	(2, 'USD', 'Доллар Соединенных Штатов Америки'),
	(3, 'EUR', 'Евро'),
	(4, 'GBP', 'Фунт стерлингов Соединенного королевства'),
	(5, 'BR', 'Белорусский рубль'),
	(6, 'AMD', 'Армянский драм')