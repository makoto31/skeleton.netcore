import _ from 'lodash';
import $ from 'jquery';

$(document).ready(()=>{

    $('#id-set').on('click', ()=>{
        const date = new FormData();
        date.append('FirstName', 'yamada');
        date.append('LastName', 'taro');

        $.ajax({
            type : 'POST'
            ,url: '/addPerson'
            ,data: date
            ,scriptCharset : 'utf-8'
            ,datatype: 'json'
            ,contentType: 'application/x-www-form-urlencoded; charset=utf-8'
            ,cashe: false
			,processData: false
			,contentType: false
        }).then(()=>{
            alert('success!');
        });
    });

    $('#id-get').on('click', ()=>{
        
        $.ajax({
            type : 'POST'
            ,url: '/persons'
            ,data: null
            ,scriptCharset : 'utf-8'
            ,datatype: 'json'
            ,contentType: 'application/x-www-form-urlencoded; charset=utf-8'
            ,cashe: false
			,processData: false
			,contentType: false
        }).then((data)=>{
            alert(JSON.stringify(data));
        });
    });
});