function get(url, method) {
  return new Promise(function(succeed, fail) {
    var request = new XMLHttpRequest();
    request.open(method, url, true);
    request.addEventListener("load", function() {
      if (request.status < 400)
        succeed(request.response);
      else
        fail(new Error("Request failed: " + request.statusText));
    });
    request.addEventListener("error", function() {
      fail(new Error("Network error"));
    });
    request.send();
  });
}
var jsonObj = {
     obj:""
};
var route_sufix;

var request_func = function(route,atr, method) { get("https://localhost:44307/api/" + route, method).then(function(response) {
  return JSON.parse(response);
}).then(function(data) {
 jsonObj.obj = data;
 console.log("succes");
 create_element(atr, jsonObj.obj);
}).catch(function(error){
  console.log("Error!!!");
  console.log(error);
}); 
};
 var get_drill = function() {
   request_func("drill?id=10", "drills", "GET");
 }
 var get_circular = function() {
  request_func("circular?id=10", "circulars", "GET");
 }

var create_element = function(atr, obj){
   let container = document.getElementById(atr);
   let ul = document.createElement("ul");
   let div = document.createElement("div");
   obj.forEach(element => {
       let li = document.createElement("li");
       set_elem("p",li,element.nameSeries, "props");
       set_elem("p",li, "мощность/Вт: " + element.power_Watt, "props");
       li.appendChild(div);
       ul.appendChild(li);
   });
   container.appendChild(ul);
}
document.addEventListener('click', function(event) {

  if (event.target.dataset.drill != undefined) {
    get_drill();
  }});
  document.addEventListener('click', function(event) {

    if (event.target.dataset.circular != undefined) { 
      get_circular ();
    }});
    var set_elem = function(elem, parent, value, class_name){
      let el =  document.createElement(elem);
       el.append(value);
       el.classList.add(class_name);
       parent.appendChild(el)};
  var get_count = function(){
    let elem = do
  }
