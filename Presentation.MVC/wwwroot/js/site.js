document.addEventListener('DOMContentLoaded', function () {

    handleProfileImageUpload()


})

function handleProfileImageUpload() {
    try {

        let fileUploader = document.querySelector('#fileUploader')

        if (fileUploader != undefined) {
            fileUploader.addEventListener('change', function () {
                if (this.files.length > 0)
                this.form.submit()
            })
        }
    }
    catch {

    }
}


const toggleMenu = () => {
        document.getElementById('menu').classList.toggle('hide');
        document.getElementsById('account-buttons').classList.toggle('hide');
    }

    const checkScreenSize = () => {
        if (window.innerWidth >= 1200) {
            document.getElementById('menu').classList.remove('hide');
            document.getElementsById('account-buttons').classList.remove('hide');
        } else {
            if (!document.getElementById('menu').classList.contains('hide')) {
                document.getElementById('menu').classList.add('hide');
            }
            if (!document.getElementById('account-buttons').classList.contains('hide')) {
                document.getElementById('account-buttons').classList.add('hide');
            }
        }
    };

    widow.addEventListener('resize', checkScreenSize);
    checkScreenSize();
