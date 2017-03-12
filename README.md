Библиотека **SecureData** позволяет очистить следующие форматы данных:
* Urls: 
``` http://test.com/user/max/info?pass=123456 -----------> http://test.com/user/XXX/info?pass=XXXXXX```
* JSON: 
``` {user: "maxim", pass:"123"} -----------> {"user":"XXXXX","pass":"XXX"}```
* XML:
```                  
<auth pass="123456">                   <auth pass=""XXXXXX"">
     <user>max</user>  ----------->     <user>XXX</user>
</auth>                                           </auth>
```
==================================================================

**Есть возможность очищать данные произвольного формата:**

class RegexDataHandler(regExp, props)
  - regExp - регулярное выражение для замены, где |REPLACED_VALUE| - данные для очистки
  - props - параметры для очистки

    **Пример** :     
```        
   string[] props = new string[] {"user", "pass"};
   string regExpStr = "(?<=\\(|REPLACED_VALUE|\\|).+?(?=\\||REPLACED_VALUE|\\))";
   var handler = new RegexDataHandler(regExpStr, props);

   var result = handler.GetSecuredData("(user|max|user)(pass|max|pass)(lang|RU|lang)");
```
```
    result: "(user|XXX|user)(pass|XXX|pass)(lang|RU|lang)"
```
==================================================================