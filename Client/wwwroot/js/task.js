function htmlFunction() {
    var javascriptData = document.getElementById('button-javascript');
    javascriptData.classList.remove('active');
    var htmlData = document.getElementById('button-html');
    htmlData.classList.add('active');
    var cssData = document.getElementById('button-css');
    cssData.classList.remove('active');

    document.getElementsByClassName('title')[0].innerHTML = 'The Basic Language of the Web : HTML';

    document.getElementsByClassName('date-post')[0].innerHTML = 'Posted by <b>Erwin</b> on Monday, 21 Juni 2021';
    document.getElementById('image').src = 'image/img-html.jpg';
    document.getElementsByClassName('topic')[0].innerHTML = 'What is HTML ?';
    document.getElementsByClassName('body-topic')[0].innerHTML = 'The HyperText Markup Language, or HTML is the standard markup language for documents designed to be displayed in a web browser. It can be assisted by technologies such as Cascading Style Sheets (CSS) and scripting languages such as JavaScript.Web browsers receive HTML documents from a web server or from local storage and render the documents into multimedia web pages.HTML describes the structure of a web page semantically and originally included cues for the appearance of the document.'
}

function cssFunction() {
    var javascriptData = document.getElementById('button-javascript');
    javascriptData.classList.remove('active');
    var htmlData = document.getElementById('button-html');
    htmlData.classList.remove('active');
    var cssData = document.getElementById('button-css');
    cssData.classList.add('active');

    document.getElementsByClassName('title')[0].innerHTML = 'The Basic Language of the Web : CSS';

    document.getElementsByClassName('date-post')[0].innerHTML = 'Posted by <b>Erwin</b> on Monday, 21 Juni 2021';
    document.getElementById('image').src = 'image/img-css.jpg';
    document.getElementsByClassName('topic')[0].innerHTML = 'What is CSS ?';
    document.getElementsByClassName('body-topic')[0].innerHTML = 'JavaScript (JS) is a lightweight, interpreted, or just-in-time compiled programming language with first-class functions. While it is most well-known as the scripting language for Web pages, many non-browser environments also use it, such as Node.js, Apache CouchDB and Adobe Acrobat. JavaScript is a prototype-based, multi-paradigm, single-threaded, dynamic language, supporting object-oriented, imperative, and declarative (e.g. functional programming) styles. Read more about JavaScript.'
}

function javascriptFunction() {
    var javascriptData = document.getElementById('button-javascript');
    javascriptData.classList.add('active');
    var htmlData = document.getElementById('button-html');
    htmlData.classList.remove('active');
    var cssData = document.getElementById('button-css');
    cssData.classList.remove('active');

    document.getElementsByClassName('title')[0].innerHTML = 'The Basic Language of the Web : Javacript';

    document.getElementsByClassName('date-post')[0].innerHTML = 'Posted by <b>Erwin</b> on Monday, 21 Juni 2021';
    document.getElementById('image').src = 'image/img-js.jpg';
    document.getElementsByClassName('topic')[0].innerHTML = 'What is Javascript ?';
    document.getElementsByClassName('body-topic')[0].innerHTML = 'The HyperText Markup Language, or HTML is the standard markup language for documents designed to be displayed in a web browser. It can be assisted by technologies such as Cascading Style Sheets (CSS) and scripting languages such as JavaScript.Web browsers receive HTML documents from a web server or from local storage and render the documents into multimedia web pages.HTML describes the structure of a web page semantically and originally included cues for the appearance of the document.'
}