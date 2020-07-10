import { Component, Input, TemplateRef, OnInit, EventEmitter, Output } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { AuthorService } from "../author.service";

@Component({
  selector: 'update-author',
  templateUrl: 'update-author.component.html'
})
export class UpdateAuthorComponent implements OnInit {
  @Input() public authorCod: number;
  @Input() public authorName: string;
  @Output() public onUpdateEvent = new EventEmitter<any>();
  @Output() private onAlertEvent = new EventEmitter<any>();

  private modalTitle: string;
  private errorAlert = false;
  private errorMessage: string;
  private modalRef: BsModalRef;

  constructor(private service: AuthorService, private modalService: BsModalService) { }

  ngOnInit() {
    this.modalTitle = this.authorName;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  onSubmit() {
    this.service
      .update({
        authorCod: this.authorCod,
        name: this.authorName
      })
      .subscribe(
        result => {
          if (!result.success) {
            this.errorAlert = true;
            this.errorMessage = result.message;

            return;
          }

          this.onUpdateEvent.emit();
          this.modalRef.hide();
          this.errorAlert = false;
          this.errorMessage = '';
          this.onAlertEvent.emit({ type: "success", message: this.authorName + " has been updated" });
        },
        error => console.error("Internal server error")
      );
  }
}
