-- task 1
select
	f.title,
	cat.name as category_name
from film f
join film_category fc on f.film_id = fc.film_id
join category cat on fc.category_id = cat.category_id
order by f.title 
limit 20;

--task 2
select
	first_name,
	last_name,
	email
from customer
where email like '%@sakilacustomer.org'
order by last_name

--task 3
select 
	rating,
	count(*) as film_count
from film
group by rating 
order by film_count desc

--task 4
select a.first_name, a.last_name, count (f.film_id) as film_count
from actor a
join film_actor fa on a.actor_id = fa.actor_id 
join film f on fa.film_id = f.film_id
group by a.actor_id, a.first_name, a.last_name
order by film_count desc
limit 10;

--task 5
select
    c.first_name,
    c.last_name,
    round(sum(p.amount), 2) as total_paid
from customer c
join payment p
    on c.customer_id = p.customer_id
join rental r
    on p.rental_id = r.rental_id
group by c.customer_id, c.first_name, c.last_name
having sum(p.amount) > 150
order by total_paid desc;
