# 1. Hafta Ödev


🏄 Derste yaşanan enstanteneler üzerine  

Kullanıcı girişi için POST metodu kullanılır.  
GET metodlarında url'de görülmesini istemediğimiz bilgiler olabilir.

Http Metodları   
OPTIONS Metodu:

Bu metod, iletişim kurmuş olduğumuz bir kaynağın, kullanılabilecek http metodlarını sunucudan sorgulamak ve kaynağın iletim seçeneklerini tanımlamak için kullanılır.   
örnek istek ->   
curl -X OPTIONS https://example.org -i
   
örnek cevap ->
   
HTTP/1.1 204 No Content    
Allow: OPTIONS, GET, HEAD, POST   
Cache-Control: max-age=604800   
Date: Thu, 13 Oct 2016 11:45:00 GMT   
Server: EOS (lax004/2813)
   
--------------------------------*****************---------------------------
   
Restful Api Geliştirin
   

- Rest standartlarna uygun olmalıdır.
- GET,POST,PUT,DELETE,PATCH methodları kullanılmalıdır.
- Http status code standartlarına uyulmalıdır. Error Handler ile 500, 400, 404, 200,
201 hatalarının standart format ile verilmesi
- Modellerde zorunlu alanların kontrolü yapılmalıdır.
- Routing kullanılmalıdır.
- Model binding işlemleri hem body den hemde query den yapılacak şekilde örneklendirilmelidir.
Bonus:
- Standart crud işlemlerine ek olarak, listeleme ve sıralama işlevleride eklenmelidir.
Örn: /api/products/list?name=abc


