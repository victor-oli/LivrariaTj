import { Component, TemplateRef, Output, EventEmitter } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { AuthorService } from "../author.service";

@Component({
  selector: 'add-author',
  templateUrl: 'add-author.component.html'
})

export class AddAuthorComponent {
  private showAlert: boolean = false;
  private alertMessage: string;
  private name: string;
  private modalRef: BsModalRef;

  @Output() public onAddEvent = new EventEmitter<any>();

  constructor(private service: AuthorService, private modalService: BsModalService) { }

  onSubmit() {
    this.service
      .add(this.name)
      .subscribe(
        result => {
          if (!result.success) {
            this.showAlert = true;
            this.alertMessage = result.message;

            return;
          }

          this.onAddEvent.emit();
          this.modalRef.hide();
          this.alertMessage = '';
          this.showAlert = false;
        },
        error => console.log(error)
      );
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
