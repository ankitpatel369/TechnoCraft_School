var seatMenu = [
  {
      '<i class="fa fa-superscript"></i> &nbsp; Change Tag': function (menuItem, menu) {
          var tag = prompt("Enter tag here"), sn = parseInt(this.parentNode.getAttribute('seat-no'));
          //this.parentNode.firstChild.innerHTML = this.parentNode.firstChild.innerHTML.charAt(0) + tag;
          if (this.parentNode.parentNode.parentNode.getAttribute('id') == 'Lowerdeck') {
              couch.lowerDeck[--sn].Tag = tag;
          }
          else {
              couch.upperDeck[--sn].Tag = tag;
          }
          if (tag != '' || tag != ' ') {
              this.parentNode.firstChild.innerHTML = tag;
              this.setAttribute("tag", tag);
          }
      }
  },
  {
      '<i class="fa fa-female"></i> &nbsp; Set ladies seat': function (menuItem, menu) {
          this.innerHTML = '<i class="fa fa-female"></i>';
          this.style.color = "red";
          this.setAttribute("isLadies", true);
          sn = parseInt(this.parentNode.getAttribute('seat-no'))
          if (this.parentNode.parentNode.parentNode.getAttribute('id') == 'Lowerdeck') {
              couch.lowerDeck[--sn].IsLadiesSeat = true;
          }
          else {
              couch.upperDeck[--sn].IsLadiesSeat = true;
          }
      }
  },
  {
      '<i class="fa fa-users"></i> &nbsp;Unset ladies seat': function (menuItem, menu) {
          this.innerHTML = "";
          this.setAttribute("isLadies", false);
          sn = parseInt(this.parentNode.getAttribute('seat-no'))
          if (this.parentNode.parentNode.parentNode.getAttribute('id') == 'Lowerdeck') {
              couch.lowerDeck[--sn].IsLadiesSeat = false;
          }
          else {
              couch.upperDeck[--sn].IsLadiesSeat = false;
          }
      }
  },
  {
      '<i class="fa fa-trash-o"></i> &nbsp; Delete': function (menuItem, menu) {
          var sn = parseInt(this.parentNode.getAttribute('seat-no'));
          if (this.parentNode.parentNode.parentNode.getAttribute('id') == 'Lowerdeck') {
              couch.lowerDeck[--sn].SeatType = '';
              couch.lowerDeck[sn].Class = '';
              couch.lowerDeck[sn].IsLadiesSeat = false;
          }
          else {
              couch.upperDeck[--sn].SeatType = '';
              couch.upperDeck[sn].Class = '';
              couch.upperDeck[sn].IsLadiesSeat = false;
          }
          this.remove();
      }
  }
];


var couch = { type: '', Bus: { UpperdeckRows: '', UpperdeckColumns: '', LowerdeckRows: '', LowerdeckColumns: '', Passage: '' }, lowerDeck: '', upperDeck: '' }, jsonUpperDeck = [], jsonLowerDeck = [];
function create(r, c, d, p, t) {
    var deck = document.getElementById(d);
    deck.innerHTML = '';
    r = parseInt(r);
    c = parseInt(c) + 1;
    p = parseInt(p) + 1;
    couch.Bus.Passage = p - 1;
    if (d == 'Lowerdeck') {
        couch.lowerDeck = [];
        jsonLowerDeck = [];
        couch.Bus.LowerdeckColumns = c;
        couch.Bus.LowerdeckRows = r;
    }
    else {
        couch.upperDeck = [];
        jsonUpperDeck = [];
        couch.Bus.UpperdeckColumns = c;
        couch.Bus.UpperdeckRows = r;
    }
    for (var i = 1, cnt = 1, a = 1; i <= r; i++) {
        var row = document.createElement('tr');
        for (var j = 1; j <= c; j++) {
            var col = document.createElement('td');
            if (j != p || i == r) {
                var seatNo = cnt++;
                var o = {
                    SeatType: "",
                    Tag: seatNo,
                    Class: '',
                    IsLadiesSeat: false,
                    Row: i,
                    Column: j,
                    Deck: d.charAt(0)
                };
                if (d == "Lowerdeck") {
                    jsonLowerDeck.push(o);
                }
                else {
                    jsonUpperDeck.push(o);
                }
                col.innerHTML = "<span id='" + d + i + "_" + (a++) + "'>" + seatNo + "</span>";
                col.ondrop = drop;
                col.ondragover = allowDrop;
                col.setAttribute("seat-no", seatNo);
            } else {
                col.style.border = "none";
                col.style.textAlign = "center";
                col.style.color = "red";
                col.innerHTML = "---";
            }
            row.appendChild(col);
        }
        deck.appendChild(row);
        a = 1;
    }
    couch.type = t;
    couch.upperDeck = jsonUpperDeck;
    couch.lowerDeck = jsonLowerDeck;
    return false;
}
function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}
function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text"), sn = parseInt(ev.target.getAttribute('seat-no'));
    if (!isNaN(sn)) {
        var clonedObj = document.getElementById(data).cloneNode(true), id = clonedObj.getAttribute('id').replace(/[0-9]/g, ''), t = couch.type;
        if (id.split('_')[1] == 'ac' && t == 'AC' || id.split('_')[1] == 'nac' && t == 'NAC') {
            clonedObj.setAttribute('id', id + sn);
            if (ev.target.childNodes.length <= 1 && ev.target.getAttribute('allow-drop') != 'false') {
                clonedObj.setAttribute('deletable', 'true');
                $(clonedObj).contextMenu(seatMenu);
                clonedObj.setAttribute("tag", this.firstChild.innerHTML);
                clonedObj.innerHTML = "";
                clonedObj.setAttribute("isladies", false);
                ev.target.appendChild(clonedObj);
                if (ev.target.parentNode.parentNode.id == "Lowerdeck") {
                    couch.lowerDeck[--sn].SeatType = clonedObj.getAttribute('type').split('-')[0];
                    couch.lowerDeck[sn].Class = clonedObj.getAttribute('class').replace('cmenu2', '');
                }
                else {
                    couch.upperDeck[--sn].SeatType = clonedObj.getAttribute('type').split('-')[0];
                    couch.upperDeck[sn].Class = clonedObj.getAttribute('class').replace('cmenu2', '');
                }
            }
        }
        else {
            if (t == 'AC')
                alert("Non AC seat is not allowed in AC bus");
            else
                alert("AC seat is not allowed in Non AC bus");
        }
    } else {
        console.log("not valid drop location....");
    }
}
function removeDraged(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text"), o = document.getElementById(data), sn = parseInt(o.parentNode.getAttribute('seat-no'));

    if (o.getAttribute('deletable') == 'true') {
        if (o.parentNode.parentNode.parentNode.id == "Lowerdeck") {
            couch.lowerDeck[--sn].SeatType = '';
            couch.lowerDeck[sn].Class = '';
            couch.lowerDeck[sn].IsLadiesSeat = false;
        }
        else {
            couch.upperDeck[--sn].SeatType = '';
            couch.upperDeck[sn].Class = '';
            couch.upperDeck[sn].IsLadiesSeat = false;
        }
        var dataNode = document.getElementById(data);
        removeElement(dataNode);
    }
}
function allowDrop(ev) {
    ev.preventDefault();
}
function getbus() {
    var BusChart = { Bus: couch.Bus };
    BusChart.Seats = [];

    var flag = true;

    for (var lD in couch.lowerDeck) {
        var seat = couch.lowerDeck[lD];
        if (seat.SeatType != '') {
            BusChart.Seats.push(seat);
            flag = false;
        } else {
            flag = true;
            break;
        }
    }

    for (var lD in couch.upperDeck) {
        var seat = couch.upperDeck[lD];
        if (seat.SeatType != '') {
            BusChart.Seats.push(seat);
            flag = false;
        } else {
            flag = true;
            break;
        }
    }

    if (flag) {
        alert("All seats are not currectly placed. Please make sure you filled seats.");
        return;
    }

    if (BusChart.Seats.length > 0) {
        Loading({ backdrop: 'static', keyboard: false });
        var Id = $("#Id").val();
        $.ajax({
            url: "/BusChart/Create",
            type: "POST",
            contentType: "text/json",
            data: JSON.stringify({ Id: Id, BusChart: BusChart }),
            success: function (d) {
                if (!d.success) {
                    LoadingMsg("Warning", d.data);
                } else {
                    Loading("hide");
                }
            },
            error: function (e, r, h) {
                LoadingMsg("Alert", "Something went wrong please contact support");
            }
        });
    }
    else
        alert("No seats found please click on generate.")
}
//load navigator
navigator.myBrowser = (function () {
    var ua = navigator.userAgent, tem,
    M = ua.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || [];
    if (/trident/i.test(M[1])) {
        tem = /\brv[ :]+(\d+)/g.exec(ua) || [];
        return 'IE ' + (tem[1] || '');
    }
    if (M[1] === 'Chrome') {
        tem = ua.match(/\b(OPR|Edge)\/(\d+)/);
        if (tem != null) return tem.slice(1).join(' ').replace('OPR', 'Opera');
    }
    M = M[2] ? [M[1], M[2]] : [navigator.appName, navigator.appVersion, '-?'];
    if ((tem = ua.match(/version\/(\d+)/i)) != null) M.splice(1, 1, tem[1]);
    return M.join(' ');
})();

var browserVersion = navigator.myBrowser.split(' ');
function removeElement(node) {
    switch (browserVersion[0]) {
        case "Firefox":
            node.parentNode.removeChild(node);
            break;
        case "Safari":
            node.remove();
            break;
        case "Opera":
            node.remove();
            break;
        case "IE":
            node.parentNode.removeChild(node);
            break;
        case "Edge":
            node.remove();
            break;
        case "Chrome":
            node.remove();
            break;
        default:
            node.remove();
            break;
    }
}