window.blazorPageFunctions = {
    changePageTitle: function (newTitle) {
        document.title = newTitle;
    },
    getTitle: function () {
        return document.title;
    }
};
