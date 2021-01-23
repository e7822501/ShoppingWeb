function getRootPath() {
    var url = location.href;
    var pathName = location.href.pathName;
    var pos = url.indexOf(pathName);
    return url.substring(0, pos);;
}