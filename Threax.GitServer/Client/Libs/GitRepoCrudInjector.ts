import * as client from 'clientlibs.ServiceClient';
import * as hyperCrud from 'hr.widgets.HypermediaCrudService';
import * as di from 'hr.di';

export class GitRepoCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listGitRepos(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListGitRepos();
    }

    public getDeletePrompt(item: client.GitRepoResult): string {
        return "Are you sure you want to delete the gitRepo?";
    }

    public getItemId(item: client.GitRepoResult): string | null {
        return String(item.data.gitRepoId);
    }

    public createIdQuery(id: string): client.GitRepoQuery | null {
        return {
            gitRepoId: id
        };
    }
}