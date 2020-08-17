import * as standardCrudPage from 'hr.widgets.StandardCrudPage';
import * as startup from 'clientlibs.startup';
import * as deepLink from 'hr.deeplink';
import { GitRepoCrudInjector } from 'clientlibs.GitRepoCrudInjector';
import { CrudTableRowControllerExtensions, CrudTableRowController } from 'hr.widgets.CrudTableRow';
import * as controller from 'hr.controller';
import * as client from 'clientlibs.ServiceClient';

class CrudRow extends CrudTableRowControllerExtensions {
    private data: client.GitRepoResult;

    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [];
    }

    constructor() {
        super();
    }

    public rowConstructed(row: CrudTableRowController, bindings: controller.BindingCollection, data: any): void {
        bindings.setListener(this);
        this.data = data;
    }

    public async copyClonePath(evt: Event): Promise<void>{
        evt.preventDefault();

        const el = document.createElement('textarea');
        el.value = this.data.data.clonePath;
        document.body.appendChild(el);
        el.select();
        document.execCommand('copy');
        document.body.removeChild(el);
    }
}

var injector = GitRepoCrudInjector;

var builder = startup.createBuilder();
builder.Services.tryAddTransient(CrudTableRowControllerExtensions, CrudRow);
deepLink.addServices(builder.Services);
standardCrudPage.addServices(builder, injector);
standardCrudPage.createControllers(builder, new standardCrudPage.Settings());