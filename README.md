# SecureDataLibrary

Разработать библиотеку по очистке secure-данных, в строках любого типа(XML, JSON, и т.д.)
Secure-данные – это логины, пароли, key и т.д. которые должны быть перетерты на ‘X’ символ.
Secure-данные  могут содержаться в URL, RequestBody или ResponsBody класса:

    class HttpResult
    {
        public string Url { get; set}
        public string RequestBody { get; set}
        public string ResponseBody { get; set}
    }

Для разных HttpResult-ов должна быть возможность построить разную логику чистку его properties.
Secure-данные могут быть формата:
1.       В параметрах GET запроса, http://test.com?user=max&pass=123456 -> http://test.com?user=XXX&pass=XXXXXX
2.       В URL вида REST, http://test.com/users/max/info -> http://test.com/users/XXX/info

 Нужно написать примеры использования библиотеки для:
    var bookingcomHttpResult = HttpResult
    {
        Url = "http://test.com/users/max/info?pass=123456",
        RequestBody = "http://test.com?user=max&pass=123456",
        ResponseBody = "http://test.com?user=max&pass=123456"
    };

В итоге должен быть solution в нем библиотека, и тесты с кейсами описанными выше.