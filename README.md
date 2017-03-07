# SecureDataLibrary

**Часть 1:**
Разработать библиотеку по очистке secure-данных, в строках любого типа(XML, JSON, и т.д.)
Secure-данные – это логины, пароли, key и т.д. которые должны быть перетерты на ‘X’ символ.
Secure-данные  могут содержаться в URL, RequestBody или ResponsBody класса:
```    class HttpResult
    {
        public string Url { get; set}
        public string RequestBody { get; set}
        public string ResponseBody { get; set}
    }
```
Для разных HttpResult-ов должна быть возможность построить разную логику чистку его properties.
Secure-данные могут быть формата:
1. В параметрах GET запроса, http://test.com?user=max&pass=123456 -> http://test.com?user=XXX&pass=XXXXXX
2. В URL вида REST, http://test.com/users/max/info -> http://test.com/users/XXX/info

 Нужно написать примеры использования библиотеки для:
 ```
    var bookingcomHttpResult = HttpResult
    {
        Url = "http://test.com/users/max/info?pass=123456",
        RequestBody = "http://test.com?user=max&pass=123456",
        ResponseBody = "http://test.com?user=max&pass=123456"
    };
```
В итоге должен быть solution в нем библиотека, и тесты с кейсами описанными выше.

**Часть 2:**
Реализовать через HttpHandler

Пример использования:
```
public class HttpHandler
{
    HttpResult _currentLog;
    public HttpResult CurrentLog { get { return _currentLog; } }

    public string Process( string url, string body, string response )
    {
        var httpResult = new HttpResult
        {
            Url = url,
            RequestBody = body,
            ResponseBody = response
        };

         //очищаем secure данные в httpResult, либо создаем новый clearedHttpResult на основе httpResult
        Log( httpResult );
        return response;
    }

    /// <summary>
    /// Логирует данные запроса, они должны быть уже без данных которые нужно защищать
    /// </summary>
    /// <param name="result"></param>

    protected void Log( HttpResult result )
    {
        _currentLog = new HttpResult
        {
            Url = result.Url,
            RequestBody = result.RequestBody,
            ResponseBody = result.ResponseBody
        };
    }
}
```
Он делает обработку HTTP запросов(как будто :) ).
Его сильно менять не нужно, задача написать такой тип (класс, интерфейс и т.д.) который можно передать одним параметром в метод Process.
Данный метод(Process) расширить можно на один параметр и с помощью этого параметра HttpHandler должен смочь почистить логи от secure-данных.
В метод Log должны приходить уже защищенные данные. Делегаты не использовать.

Тест например для bookingcomHttpResult должен выглядеть примерно:
```
[TestMethod]
public void HttpLogHandler_Process_BookingcomHttpResult_ClearSecureData()
{
    //Arrange
    var bookingcomHttpResult = HttpResult
    {
        Url = "http://test.com/users/max/info?pass=123456",
        RequestBody = "http://test.com?user=max&pass=123456",
        ResponseBody = "http://test.com?user=max&pass=123456"
    };
    var httpLogHandler = new HttpLogHandler();
	
    //Act
    httpLogHandler.Process( bookingcomHttpResult.Url, bookingcomHttpResult.RequestBody, bookingcomHttpResult.ResponseBody, передаем новый параметр(инициализируем его в блоке Arrange) );
    
	//Assert
    Assert.AreEqual("http://test.com/users/XXX/info?pass=XXXXXX", httpLogHandler.CurrentLog.Url);
    Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.RequestBody);
    Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.ResponseBody);
}
```

