import { ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/upcase}/}S_URL, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/upcase}/}_URL, SERVICES as S } from "@/config";
import { ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Details, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}DetailsDTO, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Filter, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Infos, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}InfosDTO, Create${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}, Update${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/} } from "@/domain/models";
import { I${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Service, IExtensionCommunicationService } from "@/interfaces";
import { NotifyService, uuidv4 } from "@/tools";
import { inject, injectable } from "tsyringe";

@injectable()
export class ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Service extends NotifyService<${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Infos, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Details> implements I${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Service {

  type: string = "${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/}";

  constructor(
    @inject(SERVICES.EXTENSIONCOMMUNICATIONSERVICE)
    service: IExtensionCommunicationService
  ) {
    super(service);
  }

  async get(organisationId: string, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/$1/}Id: string): Promise<${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Details> {
    const response = await axios.get(${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/upcase}/}_URL(organisationId, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/$1/}Id));
    const dto: ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}DetailsDTO = response.data;

    const ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/} = new ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Details(dto);
    this.notifyAll({
        action: "update",
        type: this.type,
        item: ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/}
    });
    return ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/};
  }

  async getMany(organisationId: string, filter?: ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Filter): Promise<${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Infos[]> {
    const response = await axios.get(buildURL(${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/upcase}/}S_URL(organisationId), filter));
    const dtos: ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}InfosDTO[] = response.data;

    const ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/}s = dtos.map(dto => new ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Infos(dto));
    this.notifyAll({
        action: "reset",
        type: this.type,
        items: [...${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/}s]
    });
    return ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/}s;
  }

  async create(organisationId: string, payload: Create${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}): Promise<${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Details> {
    const response = await axios.post(${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/upcase}/}S_URL(organisationId), payload);
    const dto: ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}DetailsDTO = response.data;

    const ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/} = new ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Details(dto);
    this.notifyAll({
        action: "add",
        type: this.type,
        items: [${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/}]
    });
    return ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/};
  }

  async update(organisationId: string, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/$1/}Id: string, payload: Update${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}): Promise<${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Details> {
    const response = await axios.post(${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/upcase}/}_URL(organisationId, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/$1/}Id), payload);
    const dto: ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}DetailsDTO = response.data;

    const ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/} = new ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Details(dto);
    this.notifyAll({
        action: "update",
        type: this.type,
        item: ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/}
    });
    return ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1}/};
  }

  async remove(organisationId: string, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Id: string): Promise<void> {
    await axios.delete(${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/upcase}/}_URL(organisationId, ${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/$1/}Id));
    
    this.notifyAll({
        action: "delete",
        type: this.type,
        items: [${TM_FILENAME_BASE/([a-zA-Z]*)(Service)/${1:/capitalize}/}Id]
    });
  }
}