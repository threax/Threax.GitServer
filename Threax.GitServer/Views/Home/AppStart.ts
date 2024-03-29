import * as client from 'Client/Libs/ServiceClient';
import * as controller from 'htmlrapier/src/controller';
import * as startup from 'Client/Libs/startup';
import { Uri } from 'htmlrapier/src/uri';
import * as loginPopup from 'htmlrapier.relogin/src/LoginPopup';

//Written this way for injection, but not really used.
class AppStart {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [client.EntryPointInjector, loginPopup.LoginPopup];
    }

    constructor(private entry: client.EntryPointInjector, private login: loginPopup.LoginPopup) {
        this.setup();
    }

    private async setup(): Promise<void> {
        //Check for login
        const entry = await this.entry.load();
        let loginResult: boolean = true;
        if (!entry.canListGitRepos()) {
            loginResult = await this.login.showLogin();
        }

        //Redirect to main page, remove AppStart from url
        if (loginResult) {
            const uri = new Uri(window.location.href);
            let path = "";
            let i = 0;
            let part: string;
            const pathEnd = uri.getPathPart(--i) || uri.getPathPart(--i);
            if (pathEnd !== null) {
                if (pathEnd.toUpperCase() === "APPSTART") {
                    while ((part = uri.getPathPart(--i)) !== null) {
                        path = '/' + part + path;
                    }
                    if (!path) {
                        path = '/';
                    }
                    window.location.href = path;
                }
            }
        }
    }
}

const builder = startup.createBuilder();
builder.Services.addTransient(AppStart, AppStart);
builder.createUnbound(AppStart);