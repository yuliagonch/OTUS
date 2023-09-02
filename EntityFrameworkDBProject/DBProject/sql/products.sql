CREATE TABLE PRODUCTS
(
	PRODUCT_ID SERIAL PRIMARY KEY,
	PRODUCT_NAME CHARACTER VARYING(120) NOT NULL,
	REMARKS CHARACTER VARYING(400)
);

COMMENT ON TABLE PRODUCTS IS 'Продукты';
COMMENT ON COLUMN PRODUCTS.PRODUCT_ID IS 'Идентификатор продукта';
COMMENT ON COLUMN PRODUCTS.PRODUCT_NAME IS 'Название продукта';
COMMENT ON COLUMN PRODUCTS.REMARKS IS 'Комментарии';

INSERT INTO PRODUCTS (PRODUCT_NAME, REMARKS) VALUES
	('Депозит', 'Банковский депозит'),
	('Дебетовая карта', 'Дебетовая карта'),
	('Кредитная карта', 'Кредитная карта'),
	('Кредит', 'Кредит'),
	('Ипотека', 'Кредит на покупку недвижимого имущества');