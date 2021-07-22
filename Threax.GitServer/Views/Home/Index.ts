import * as standardCrudPage from 'htmlrapier.widgets/src/StandardCrudPage';
import * as startup from 'Client/Libs/startup';
import * as deepLink from 'htmlrapier/src/deeplink';
import { GitRepoCrudInjector } from 'Client/Libs/GitRepoCrudInjector';
import { CrudTableRowControllerExtensions, CrudTableRowController } from 'htmlrapier.widgets/src/CrudTableRow';
import * as controller from 'htmlrapier/src/controller';
import * as client from 'Client/Libs/ServiceClient';

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