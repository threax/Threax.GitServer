import * as client from 'clientlibs.ServiceClient';
import * as hyperCrud from 'hr.widgets.HypermediaCrudService';
import * as di from 'hr.di';

export class AuthorizedKeyCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listAuthorizedKeys(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListAuthorizedKeys();
    }

    public getDeletePrompt(item: client.AuthorizedKeyResult): string {
        return "Are you sure you want to delete the authorizedKey?";
    }

    public getItemId(item: client.AuthorizedKeyResult): string | null {
        return String(item.data.authorizedKeyId);
    }

    public createIdQuery(id: string): client.AuthorizedKeyQuery | null {
        return {
            authorizedKeyId: id
        };
    }
}