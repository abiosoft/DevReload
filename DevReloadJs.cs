namespace Abiosoft.DotNet.DevReload
{
    static class Js
    {
        public const string Tag = @"<script src=""/__DevReload""></script>";
        public const string Script = @"
(function() {

  var el = document.createElement('div');
  el.id = 'reload';
  el.innerHTML = 'DevReload - Reloading page...';
  el.style.cssText = 'display:none; position: absolute; left: 0; top: 0; background-color: #fff; z-index: 9999; padding: 2px; border: solid 1px #333';
  document.body.appendChild(el);

  var time = '';

  function check() {
    fetch('/__DevReload', {
      method: 'GET',
      headers: { ping: 'true' },
    })
      .then(function(response) {
        return response.text();
      })
      .then(function(body) {
        if (time == '') {
          time = body;
        }
        if (time != body) {
          console.log('time is different', time, body, 'reloading...');
          document.getElementById('reload').style.display = 'block';
          location.reload();
        }
      })
      .catch(error => console.error(error));
  }

  setInterval(check, 1000);
})();
 ";
    }



}