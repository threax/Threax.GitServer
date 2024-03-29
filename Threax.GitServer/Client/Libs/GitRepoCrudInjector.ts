import * as client from 'Client/Libs/ServiceClient';
import * as hyperCrud from 'htmlrapier.widgets/src/HypermediaCrudService';
import * as di from 'htmlrapier/src/di';

export class GitRepoCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        const entry = await this.injector.load();
        return entry.listGitRepos(query);
    }

    async canList(): Promise<boolean> {
        const entry = await this.injector.load();
        return entry.canListGitRepos();
    }

    public getDeletePrompt(item: client.GitRepoResult): string {
        return `Are you sure you want to delete ${item.data.name}?`;
    }

    public getItemId(item: client.GitRepoResult): string | null {
        return String(item.data.name);
    }

    public createIdQuery(id: string): client.GitRepoQuery | null {
        return {
            name: id
        };
    }
}