select p.NAME, c.NAME from PRODUCT p
left outer join PRODUCT_CATEGORY p_c on p_c.PRODUCT_ID = p.ID
left outer join CATEGORY c on p_c.CATEGORY_ID = c.ID